using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;


namespace LithologyLog.Web.Lang
{
    public class LangService
    {
        public string Lang { get; set; }

        // makes sure check is done only when object is created
        public LangService(IHttpContextAccessor accessor)
        {
            var request = accessor.HttpContext.Features.Get<IRequestCultureFeature>();
            Lang = null;

            if (request != null)
            {
                Lang = request.RequestCulture.Culture.Name;
            }

        }

        public string ChangeUrl(string url, string lang)
        {
            string[] array = url.Split('/');

            string langUrl = "/" + lang;

            for (int i = 2; i < array.Length; i++)
            {
                langUrl += string.Concat("/", array[i]);
            }

            return langUrl;

        }

        // optional to simplify usage further. 
        public static implicit operator string(LangService lang) => lang.Lang;
    }
}
