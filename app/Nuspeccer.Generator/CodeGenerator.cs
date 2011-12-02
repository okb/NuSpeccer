#region License

// --------------------------------------------------
// Copyright © 2003–2010 OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using Microsoft.CSharp;

namespace Nuspeccer.Generator
{
    public static class CodeGenerator
    {
        public static void GenerateCode(string xsdFilepath, string codeOutPath, string nameSpace)
        {
            FileStream stream = File.OpenRead(xsdFilepath);
            XmlSchema xsd = XmlSchema.Read(stream, ValidationCallbackOne);

            // Remove namespaceattribute from schema
            xsd.TargetNamespace = null;

            XmlSchemas xsds = new XmlSchemas { xsd };
            XmlSchemaImporter imp = new XmlSchemaImporter(xsds);
            //imp.Extensions.Add(new CustomSchemaImporterExtension());

            CodeNamespace ns = new CodeNamespace(nameSpace);
            XmlCodeExporter exp = new XmlCodeExporter(ns);

            foreach (XmlSchemaObject item in xsd.Items)
            {
                if (!(item is XmlSchemaElement))
                    continue;

                XmlSchemaElement xmlSchemaElement = (XmlSchemaElement)item;
                XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(xmlSchemaElement.Name, xsd.TargetNamespace);
                XmlTypeMapping map = imp.ImportTypeMapping(xmlQualifiedName);

                exp.ExportTypeMapping(map);
            }

            // Remove all the attributes from each type in the CodeNamespace, except
            // System.Xml.Serialization.XmlTypeAttribute
            RemoveAttributes(ns);

            ToProperties(ns);

            CodeCompileUnit compileUnit = new CodeCompileUnit();

            compileUnit.Namespaces.Add(ns);
            CSharpCodeProvider provider = new CSharpCodeProvider();

            using (StreamWriter sw = new StreamWriter(codeOutPath, false))
            {
                CodeGeneratorOptions codeGeneratorOptions = new CodeGeneratorOptions();
                provider.GenerateCodeFromCompileUnit(compileUnit, sw, codeGeneratorOptions);
            }
        }


        private static void RemoveAttributes(CodeNamespace code)
        {
            foreach (CodeTypeDeclaration codeType in code.Types)
            {
                CodeAttributeDeclaration xmlTypeAttribute = null;
                foreach (CodeAttributeDeclaration codeAttribute in codeType.CustomAttributes)
                {
                    Console.WriteLine(codeAttribute.Name);
                    if (codeAttribute.Name == "System.Xml.Serialization.XmlTypeAttribute")
                        xmlTypeAttribute = codeAttribute;
                }
                codeType.CustomAttributes.Clear();
                if (xmlTypeAttribute != null)
                    codeType.CustomAttributes.Add(xmlTypeAttribute);
            }
        }


        private static void ToProperties(CodeNamespace code)
        {
            foreach (CodeTypeDeclaration type in code.Types)
            {
                if (!type.IsClass && !type.IsStruct)
                    continue;

                // Turn fields to props
                CodeTypeMember[] members = new CodeTypeMember[type.Members.Count];
                type.Members.CopyTo(members, 0);
                foreach (CodeTypeMember member in members)
                {
                    // Process fields only.
                    if (!(member is CodeMemberField))
                        continue;

                    // Create property
                    CodeMemberProperty prop = new CodeMemberProperty
                    {
                        Name = member.Name,
                        Attributes = member.Attributes,
                        Type = ((CodeMemberField)member).Type
                    };
                    // Copy attributes from field to the property.
                    prop.CustomAttributes.AddRange(member.CustomAttributes);
                    member.CustomAttributes.Clear();
                    // Copy comments from field to the property.
                    prop.Comments.AddRange(member.Comments);
                    member.Comments.Clear();
                    // Modify the field.
                    member.Attributes = MemberAttributes.Private;
                    Char[] letters = member.Name.ToCharArray();
                    letters[0] = Char.ToLower(letters[0]);
                    member.Name = String.Concat("_", new string(letters));
                    prop.HasGet = true;
                    prop.HasSet = true;
                    // Add get/set statements pointing to field. Generates:
                    // return this._fieldname;
                    prop.GetStatements.Add(
                        new CodeMethodReturnStatement(
                            new CodeFieldReferenceExpression(
                                new CodeThisReferenceExpression(), member.Name)));
                    // Generates:
                    // this._fieldname = value;
                    prop.SetStatements.Add(
                        new CodeAssignStatement(
                            new CodeFieldReferenceExpression(
                                new CodeThisReferenceExpression(), member.Name),
                            new CodeArgumentReferenceExpression("value")));

                    type.Members.Add(prop);
                }
            }
        }


        private static void ValidationCallbackOne(object sender, ValidationEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}