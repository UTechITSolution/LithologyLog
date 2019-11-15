using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LithologyLog.Web.Models;
using LithologyLog.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LithologyLog.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IColumRepository _columRepository;

        public ReportController(IColumRepository columRepository)
        {
            _columRepository = columRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportView()
        {
            return View();
        }

        public JsonResult Column()
        {
            _columRepository.Fill();

            var columns = _columRepository.GetColumns();

            ICollection<Column_3> columns_3 = new List<Column_3>
            {
                new Column_3 { Value= "98.97",Y= 74.97f }
            };

            ICollection<Column_4> columns_4 = new List<Column_4>
            {
                new Column_4 { Value= "1.5",Y= 98.97f }
            };

            ICollection<Column_5> columns_5 = new List<Column_5>
            {
               new Column_5 { Value= "1.5",Y= 98.97f }
            };

            ICollection<Column_6> columns_6 = new List<Column_6>
            {
               new Column_6 { ImageSrc="/assets/images/Texture/1.png",Y= 100.4f,Y2=76.97f }
            };

            ICollection<Column_12> columns_12 = new List<Column_12>
            {
               new Column_12 { Value= "anQIV",Y= 98.97f },
                new Column_12 { Value= "Xəzər mərtəbəsi",Y= 86.97f }
            };

            PageCreationMember pageCreationMember = new PageCreationMember
            {
                Columns = columns,
                RullerLeftBeginNumber = 100.4f,
                Columns_3 = columns_3,
                Columns_4 = columns_4,
                Columns_5 = columns_5,
                Columns_6 = columns_6,
                Columns_12 = columns_12,
            };

            var json = JsonConvert.SerializeObject(pageCreationMember);

            return Json(json);
        }
    }
}