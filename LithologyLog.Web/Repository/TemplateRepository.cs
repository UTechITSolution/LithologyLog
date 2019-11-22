using LithologyLog.Web.Lang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Repository
{
    public interface ITemplateRepository
    {
        string GetHeaderHtml();
    }

    public class TemplateRepository : ITemplateRepository
    {
        private readonly LocalizerService _localizerService;

        public TemplateRepository(LocalizerService localizerService)
        {
            _localizerService = localizerService;
        }

        public string GetHeaderHtml()
        {
            string html = File.ReadAllText(Path.Combine("wwwroot", "Resource", "HeaderTemplate.html"));

            string[] words = new string[]
            {
                "HeaderClient",
                "HeaderContractor",
                "HeaderDrillingEquipment",
                "HeaderSite",
                "HeaderProject",
                "HeaderMethode",
                "HeaderBorehole",
                "HeaderGroundDedectionWatherLevel",
                "HeaderDepth",
                "HeaderGroundStableWatherLevel",
                "HeaderDiameter",
                "HeaderElavation",
                "HeaderCoreRecovery",
                "HeaderBoreholeCoordinate"
            };

            foreach (var word in words)
            {
                html = html.Replace(word+" ", _localizerService[word]);
            }

            return html;
        }
    }
}
