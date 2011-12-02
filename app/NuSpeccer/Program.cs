#region License

// --------------------------------------------------
// Copyright © 2003–2010 OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace NuSpeccer
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            string filename = "";
            if (args.Length == 0)
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    Multiselect = false
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    filename = openFileDialog1.FileName;
                else
                    return;
            }
            else
                filename = Path.GetFullPath(args[0]);

            if (File.Exists(filename))
            {
                Package package = new Package();
                Assembly executingAssembly = Assembly.GetExecutingAssembly();

                using (Stream stream = executingAssembly
                    .GetManifestResourceStream(executingAssembly.GetName().Name + ".Package.nuspec"))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var xml = reader.ReadToEnd();
                        package = Package.Deserialize(xml);
                    }
                }

                Assembly assembly = Assembly.LoadFile(filename);
                AssemblyInfoHelper helper = new AssemblyInfoHelper(assembly);
                IDictionary<string, string> allAttributes = helper.GetAllAttributes();

                allAttributes.Add("version", helper.FileVersion);
                allAttributes.Add("id", helper.AssemblyName);
                allAttributes.Add("authors", helper.Company);
                allAttributes.Add("owners", helper.Company);

                PropertyInfo[] properties = typeof(PackageMetadata).GetProperties(
                    BindingFlags.Public |
                    BindingFlags.DeclaredOnly |
                    BindingFlags.Instance);

                foreach (KeyValuePair<string, string> attribute in allAttributes)
                {
                    foreach (PropertyInfo propertyInfo in
                        properties.Where(propertyInfo => propertyInfo.Name.ToLower().Equals(attribute.Key.ToLower())).
                            Where(propertyInfo => propertyInfo.CanWrite))
                        propertyInfo.SetValue(package.Metadata, attribute.Value, null);
                }

                var version = helper.RuntimeVersion;
                package.Files.Add(new PackageFile
                    {
                        Src = helper.FilePath,
                        Target = "lib"
                    });

                var outFile = Path.GetFileName(filename.Replace(".dll", ".nuspec"));
                package.SaveToFile(outFile);
                Console.WriteLine("Done! " + outFile);
            }
            else
                Console.WriteLine("File does not exist!");
        }
    }
}