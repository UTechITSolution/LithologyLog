using Microsoft.Extensions.Localization;
using System.Reflection;

namespace LithologyLog.Web.Lang
{
    public class LocalizerService
    {
        private readonly IStringLocalizer _localizer;

        public string this[string key]
        {
            get
            {
                return _localizer[key];
            }
 
        }

        public LocalizerService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResources", assemblyName.Name);
        }

        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }


    }
}
