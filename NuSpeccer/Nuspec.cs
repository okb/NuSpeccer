#region License

// --------------------------------------------------
// Copyright © 2003–2010 OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace NuSpeccer
{
    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(ElementName = "package")]
    public partial class Package
    {
        private static XmlSerializer serializer;
        private List<PackageFile> filesField;
        private PackageMetadata metadataField;


        public Package()
        {
            this.filesField = new List<PackageFile>();
            this.metadataField = new PackageMetadata();
        }


        [XmlArray(IsNullable = true, ElementName = "files")]
        [XmlArrayItem("file", IsNullable = false)]
        public List<PackageFile> Files
        {
            get { return this.filesField; }
            set { this.filesField = value; }
        }

        [XmlElement("metadata")]
        public PackageMetadata Metadata
        {
            get { return this.metadataField; }
            set { this.metadataField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(Package));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an Package object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output Package object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out Package obj, out Exception exception)
        {
            exception = null;
            obj = default(Package);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out Package obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static Package Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((Package)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an Package object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Package object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Package obj, out Exception exception)
        {
            exception = null;
            obj = default(Package);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out Package obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static Package LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current Package object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current Package object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }

    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("packageMetadata")]
    public partial class PackageMetadata
    {
        private static XmlSerializer serializer;
        private string authorsField;
        private string copyrightField;
        private List<PackageMetadataDependency> dependenciesField;
        private string descriptionField;
        private List<PackageMetadataFrameworkAssembly> frameworkAssembliesField;
        private string iconUrlField;
        private string idField;
        private string languageField;

        private string licenseUrlField;
        private string ownersField;

        private string projectUrlField;
        private List<PackageMetadataReference> referencesField;
        private string releaseNotesField;

        private Nullable<bool> requireLicenseAcceptanceField;

        private string summaryField;

        private string tagsField;
        private string titleField;
        private string versionField;


        public PackageMetadata()
        {
            this.referencesField = new List<PackageMetadataReference>();
            this.frameworkAssembliesField = new List<PackageMetadataFrameworkAssembly>();
            this.dependenciesField = new List<PackageMetadataDependency>();
            this.languageField = "en-US";
        }


        [XmlElement("authors")]
        public string Authors
        {
            get { return this.authorsField; }
            set { this.authorsField = value; }
        }

        [XmlElement("copyright")]
        public string Copyright
        {
            get { return this.copyrightField; }
            set { this.copyrightField = value; }
        }

        [XmlArrayItem("dependency", IsNullable = false)]
        [XmlArray("dependencies")]
        public List<PackageMetadataDependency> Dependencies
        {
            get { return this.dependenciesField; }
            set { this.dependenciesField = value; }
        }

        [XmlElement("description")]
        public string Description
        {
            get { return this.descriptionField; }
            set { this.descriptionField = value; }
        }

        [XmlArrayItem("frameworkAssembly", IsNullable = false)]
        [XmlArray("frameworkAssemblies")]
        public List<PackageMetadataFrameworkAssembly> FrameworkAssemblies
        {
            get { return this.frameworkAssembliesField; }
            set { this.frameworkAssembliesField = value; }
        }

        [XmlElement(DataType = "anyURI", ElementName = "iconUrl")]
        public string IconUrl
        {
            get { return this.iconUrlField; }
            set { this.iconUrlField = value; }
        }

        [XmlElement("id")]
        public string Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        [DefaultValue("en-US")]
        [XmlElement("language")]
        public string Language
        {
            get { return this.languageField; }
            set { this.languageField = value; }
        }

        [XmlElement(DataType = "anyURI", ElementName = "licenseUrl")]
        public string LicenseUrl
        {
            get { return this.licenseUrlField; }
            set { this.licenseUrlField = value; }
        }

        [XmlElement("owners")]
        public string Owners
        {
            get { return this.ownersField; }
            set { this.ownersField = value; }
        }

        [XmlElement(DataType = "anyURI", ElementName = "projectUrl")]
        public string ProjectUrl
        {
            get { return this.projectUrlField; }
            set { this.projectUrlField = value; }
        }

        [XmlArrayItem("reference", IsNullable = false)]
        [XmlArray("references")]
        public List<PackageMetadataReference> References
        {
            get { return this.referencesField; }
            set { this.referencesField = value; }
        }

        [XmlElement("releaseNotes")]
        public string ReleaseNotes
        {
            get { return this.releaseNotesField; }
            set { this.releaseNotesField = value; }
        }

        [XmlElement("requireLicenseAcceptance")]
        public Nullable<bool> RequireLicenseAcceptance
        {
            get { return this.requireLicenseAcceptanceField; }
            set { this.requireLicenseAcceptanceField = value; }
        }

        [XmlIgnore()]
        [XmlElement("requireLicenseAcceptanceSpecified")]
        public bool RequireLicenseAcceptanceSpecified
        {
            get { return RequireLicenseAcceptance.HasValue; }
        }

        [XmlElement("summary")]
        public string Summary
        {
            get { return this.summaryField; }
            set { this.summaryField = value; }
        }

        [XmlElement("tags")]
        public string Tags
        {
            get { return this.tagsField; }
            set { this.tagsField = value; }
        }

        [XmlElement("title")]
        public string Title
        {
            get { return this.titleField; }
            set { this.titleField = value; }
        }

        [XmlElement("version")]
        public string Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(PackageMetadata));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an PackageMetadata object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PackageMetadata object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PackageMetadata obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadata);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out PackageMetadata obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static PackageMetadata Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PackageMetadata)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an PackageMetadata object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PackageMetadata object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PackageMetadata obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadata);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out PackageMetadata obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static PackageMetadata LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadata object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadata object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }

    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("packageMetadataDependency")]
    public partial class PackageMetadataDependency
    {
        private static XmlSerializer serializer;
        private string idField;

        private string versionField;

        [XmlAttribute(AttributeName = "id")]
        public string Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        [XmlAttribute(AttributeName = "version")]
        public string Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(PackageMetadataDependency));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an PackageMetadataDependency object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PackageMetadataDependency object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PackageMetadataDependency obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataDependency);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out PackageMetadataDependency obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static PackageMetadataDependency Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PackageMetadataDependency)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an PackageMetadataDependency object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PackageMetadataDependency object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PackageMetadataDependency obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataDependency);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out PackageMetadataDependency obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static PackageMetadataDependency LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataDependency object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataDependency object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }

    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("packageMetadataFrameworkAssembly")]
    public partial class PackageMetadataFrameworkAssembly
    {
        private static XmlSerializer serializer;
        private string assemblyNameField;

        private string targetFrameworkField;

        [XmlAttribute(AttributeName = "assemblyName")]
        public string AssemblyName
        {
            get { return this.assemblyNameField; }
            set { this.assemblyNameField = value; }
        }

        [XmlAttribute(AttributeName = "targetFramework")]
        public string TargetFramework
        {
            get { return this.targetFrameworkField; }
            set { this.targetFrameworkField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(PackageMetadataFrameworkAssembly));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an PackageMetadataFrameworkAssembly object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PackageMetadataFrameworkAssembly object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PackageMetadataFrameworkAssembly obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataFrameworkAssembly);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out PackageMetadataFrameworkAssembly obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static PackageMetadataFrameworkAssembly Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PackageMetadataFrameworkAssembly)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an PackageMetadataFrameworkAssembly object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PackageMetadataFrameworkAssembly object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(
            string fileName, out PackageMetadataFrameworkAssembly obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataFrameworkAssembly);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out PackageMetadataFrameworkAssembly obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static PackageMetadataFrameworkAssembly LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataFrameworkAssembly object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataFrameworkAssembly object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }

    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("packageMetadataReference")]
    public partial class PackageMetadataReference
    {
        private static XmlSerializer serializer;
        private string fileField;

        [XmlAttribute(AttributeName = "file")]
        public string File
        {
            get { return this.fileField; }
            set { this.fileField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(PackageMetadataReference));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an PackageMetadataReference object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PackageMetadataReference object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PackageMetadataReference obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataReference);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out PackageMetadataReference obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static PackageMetadataReference Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PackageMetadataReference)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an PackageMetadataReference object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PackageMetadataReference object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PackageMetadataReference obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageMetadataReference);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out PackageMetadataReference obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static PackageMetadataReference LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataReference object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageMetadataReference object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }

    [GeneratedCode("Nuspec", "1.0.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("packageFile")]
    public partial class PackageFile
    {
        private static XmlSerializer serializer;
        private string excludeField;
        private string srcField;

        private string targetField;

        [XmlAttribute(AttributeName = "exclude")]
        public string Exclude
        {
            get { return this.excludeField; }
            set { this.excludeField = value; }
        }

        [XmlAttribute(AttributeName = "src")]
        public string Src
        {
            get { return this.srcField; }
            set { this.srcField = value; }
        }

        [XmlAttribute(AttributeName = "target")]
        public string Target
        {
            get { return this.targetField; }
            set { this.targetField = value; }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                    serializer = new XmlSerializer(typeof(PackageFile));
                return serializer;
            }
        }

        #region Serialize/Deserialize

        /// <summary>
        /// Deserializes workflow markup into an PackageFile object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output PackageFile object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out PackageFile obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageFile);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool Deserialize(string xml, out PackageFile obj)
        {
            Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }


        public static PackageFile Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((PackageFile)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                    stringReader.Dispose();
            }
        }


        /// <summary>
        /// Deserializes xml markup from file into an PackageFile object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PackageFile object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PackageFile obj, out Exception exception)
        {
            exception = null;
            obj = default(PackageFile);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }


        public static bool LoadFromFile(string fileName, out PackageFile obj)
        {
            Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }


        public static PackageFile LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                    file.Dispose();
                if ((sr != null))
                    sr.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageFile object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }


        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                    streamWriter.Dispose();
            }
        }


        /// <summary>
        /// Serializes current PackageFile object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                    streamReader.Dispose();
                if ((memoryStream != null))
                    memoryStream.Dispose();
            }
        }

        #endregion
    }
}