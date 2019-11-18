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

            //_columRepository.Hide(3, 4, 5);

            var columns = _columRepository.GetColumns();



            ICollection<Column_3> columns_3 = new List<Column_3>
            {
                new Column_3 { Value= "98.97",Y= 98.97f }
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

            ICollection<Column_7> columns_7 = new List<Column_7>
            {
               new Column_7 { Value="2.50 - 2.80", Y= 98.97f, Length1=2.50f, Length2=2.80f }
            };

            ICollection<Column_8> columns_8 = new List<Column_8>
            {
               new Column_8 { Value= "Zeytuni boz rəngli tərkibində dəmir oksidi və qum laycıqları olan SIX PLASTİK GİL",Y= 98.97f,TextHeight= 98.97f }
            };

            ICollection<Column_9> columns_9 = new List<Column_9>
            {
               new Column_9 {Value1=8, Value2=14,Value3=10, Y= 98.97f},
               new Column_9 {Value1=8, Value2=14,Value3=10, Y= 95.97f}
            };

            ICollection<Column_12> columns_12 = new List<Column_12>
            {
               new Column_12 { Value= "anQIV",Y= 98.97f },
                new Column_12 { Value= "Xəzər mərtəbəsi",Y= 86.97f }
            };

            ICollection<Column_10> columns_10 = new List<Column_10>
            {
               new Column_10 { Value= "24", Y= 98.97f },
               new Column_10 { Value= "48", Y= 95.97f }
            };

            PageCreationMember pageCreationMember = new PageCreationMember
            {
                Columns = columns,
                RullerLeftBeginNumber = 100.4f,
                Columns_3 = columns_3,
                Columns_4 = columns_4,
                Columns_5 = columns_5,
                Columns_6 = columns_6,
                Columns_7 = columns_7,
                Columns_8 = columns_8,
                Columns_9 = columns_9,
                Columns_10 = columns_10,
                Columns_12 = columns_12,
            };

            var json = JsonConvert.SerializeObject(pageCreationMember);

            return Json(json);
        }
    }
}