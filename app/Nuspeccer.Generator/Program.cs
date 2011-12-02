#region License

// --------------------------------------------------
// Copyright © 2003–2010 OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using Xsd2Code.Library;
using Xsd2Code.Library.Helpers;

namespace Nuspeccer.Generator
{
    public static class NuspecGenerator
    {
        public static void Main(string[] args)
        {
            const string filepath = "nuspec.xsd";
            const string outPath = @"..\..\..\NuSpeccer\Nuspec.cs";
            const string nameSpace = "NuSpeccer";

            GenereateCodeWithXsd2Code(filepath, outPath, nameSpace);
            //CodeGenerator.GenerateCode(filepath, outPath, nameSpace);
        }


        private static void GenereateCodeWithXsd2Code(string xsdFilepath, string codeOutPath, string nameSpace)
        {
            GeneratorParams generatorParams = new GeneratorParams
            {
                InputFilePath = xsdFilepath,
                OutputFilePath = codeOutPath,
                Language = GenerationLanguage.CSharp,
                NameSpace = nameSpace,
                CollectionObjectType = CollectionType.List,
                PropertyParams =
                    {
                        AutomaticProperties = true,
                        PascalCaseProperty = true
                    },
                Serialization = { Enabled = true, GenerateXmlAttributes = true }
            };

            // Create an instance of Generator
            GeneratorFacade generator = new GeneratorFacade(generatorParams);

            // Generate code
            Result<string> result = generator.Generate();
        }
    }
}