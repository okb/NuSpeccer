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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NuSpeccer
{
    public class AssemblyInfoHelper
    {
        private static Assembly mAssembly;


        public AssemblyInfoHelper(Type type)
        {
            mAssembly = Assembly.GetAssembly(type);
        }


        public AssemblyInfoHelper(Assembly assembly)
        {
            mAssembly = assembly;
        }


        public string AssemblyName
        {
            get { return mAssembly.GetName().Name.ToString(); }
        }

        public string AssemblyVersion
        {
            get { return mAssembly.GetName().Version.ToString(); }
        }

        public string Company
        {
            get { return CustomAttributes<AssemblyCompanyAttribute>().Company; }
        }

        public string Copyright
        {
            get { return CustomAttributes<AssemblyCopyrightAttribute>().Copyright; }
        }

        public string Description
        {
            get { return CustomAttributes<AssemblyDescriptionAttribute>().Description; }
        }

        public string FileName
        {
            get
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(mAssembly.Location);
                return fvi.OriginalFilename;
            }
        }

        public string FilePath
        {
            get
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(mAssembly.Location);
                return fvi.FileName;
            }
        }

        public string FileVersion
        {
            get
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(mAssembly.Location);
                return fvi.FileVersion;
            }
        }

        public string Guid
        {
            get { return CustomAttributes<GuidAttribute>().Value; }
        }

        public string Product
        {
            get { return CustomAttributes<AssemblyProductAttribute>().Product; }
        }

        public string RuntimeVersion
        {
            get { return mAssembly.ImageRuntimeVersion; }
        }

        public string Title
        {
            get { return CustomAttributes<AssemblyTitleAttribute>().Title; }
        }

        public string Trademark
        {
            get { return CustomAttributes<AssemblyTrademarkAttribute>().Trademark; }
        }


        public IDictionary<string, string> GetAllAttributes()
        {
            Dictionary<string, IList<CustomAttributeTypedArgument>> attributes = mAssembly.GetCustomAttributesData()
                .ToDictionary(a => a.Constructor.ReflectedType.Name, a => a.ConstructorArguments);
            return attributes
                .Where(a => a.Key.StartsWith("Assembly"))
                .ToDictionary(
                    a => a.Key.Replace("Assembly", "").Replace("Attribute", ""),
                    a => a.Value.First().Value.ToString()
                );
        }


        private static T CustomAttributes<T>()
            where T : Attribute
        {
            object[] customAttributes = mAssembly.GetCustomAttributes(typeof(T), false);

            if ((null != customAttributes) && (customAttributes.Length > 0))
                return ((T)customAttributes[0]);

            throw new InvalidOperationException();
        }
    }
}