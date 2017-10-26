using System.Diagnostics;
using System.Reflection;

namespace Skunk.Website.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Gets the start payment URL.
        /// </summary>
        /// <param name="buildingBlock">The building block.</param>
        /// <returns></returns>
        public static string GetFileVersion(this System.Web.Mvc.HtmlHelper htmlHelper)
        {
            string fileVersion = CacheHelper.Get<string>("Application_FileVersion");

            if (fileVersion == null)
            {
                System.Reflection.Assembly currentApplication = System.Reflection.Assembly.GetAssembly(typeof(Skunk.Website.Helpers.ExtensionMethods));
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(currentApplication.Location);

                fileVersion = fileVersionInfo.FileVersion;

                CacheHelper.InsertWithAbsoluteExpiration<string>(fileVersion, "Application_FileVersion", 60);
            }

            return fileVersion;
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <param name="buildingBlock">The building block.</param>
        /// <returns></returns>
        public static string GetAssemblyVersion(this System.Web.Mvc.HtmlHelper htmlHelper)
        {
            string assemblyVersion = CacheHelper.Get<string>("Application_AssemblyVersion");

            if (assemblyVersion == null)
            {
                assemblyVersion = System.Reflection.Assembly.GetAssembly(typeof(Skunk.Website.Helpers.ExtensionMethods)).GetName().Version.ToString();
                CacheHelper.InsertWithAbsoluteExpiration<string>(assemblyVersion, "Application_AssemblyVersion", 60);
            }

            return assemblyVersion;
        }

        /// <summary>
        /// Gets the name of the company.
        /// </summary>
        /// <param name="buildingBlock">The building block.</param>
        /// <returns></returns>
        public static string GetCompanyName(this System.Web.Mvc.HtmlHelper htmlHelper)
        {
            string companyName = CacheHelper.Get<string>("Application_CompanyName");

            if (companyName == null)
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(Skunk.Website.Helpers.ExtensionMethods)).Location);

                companyName = fileVersionInfo.CompanyName;
                CacheHelper.InsertWithAbsoluteExpiration<string>(companyName, "Application_CompanyName", 60);
            }

            return companyName;
        }

        /// <summary>
        /// Gets the legal copyright.
        /// </summary>
        /// <param name="buildingBlock">The building block.</param>
        /// <returns></returns>
        public static string GetLegalCopyright(this System.Web.Mvc.HtmlHelper htmlHelper)
        {
            string legalCopyright = CacheHelper.Get<string>("Application_LegalCopyright");

            if (legalCopyright == null)
            {
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(Skunk.Website.Helpers.ExtensionMethods)).Location);

                legalCopyright = fileVersionInfo.LegalCopyright;
                CacheHelper.InsertWithAbsoluteExpiration<string>(legalCopyright, "Application_LegalCopyright", 60);
            }

            return legalCopyright;
        }
    }
}