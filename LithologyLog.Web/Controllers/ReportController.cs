﻿using LithologyLog.Web.Facades;
using LithologyLog.Web.Models;
using LithologyLog.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LithologyLog.Model;
using LithologyLog.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LithologyLog.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IColumRepository _columRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IReportFacade _reportFacade;
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IColumRepository columRepository, 
                                ITemplateRepository templateRepository, 
                                IReportFacade reportFacade,
                                IUnitOfWork unitOfWork)
        {
            _columRepository = columRepository;
            _templateRepository = templateRepository;
            _reportFacade = reportFacade;
            _unitOfWork = unitOfWork;
        }

        public IActionResult LoadDataForTable()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var model = _reportFacade.GetAll();

            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m =>  m.ProjectName.StartsWith(searchValue)
                                         || m.ClientOrg.StartsWith(searchValue)
                                         || m.ContractorOrg.StartsWith(searchValue)
                                         || m.SiteName.StartsWith(searchValue)
                                         );
            }

            //total number of rows count 
            recordsTotal = model.Count();
            //Paging 
            var data = model.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.OrgList = _unitOfWork.Repository<Organization>().Query()
                                      .Select(a => new SelectListItem()
                                      {
                                          Value = a.Id.ToString(),
                                          Text = a.Name
                                      })
                                    .ToList();

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create(string s)
        {
            return Json("");
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
                new Column_3 { Value= "98.97",Y= 98.97f }
            };

            ICollection<Column_4> columns_4 = new List<Column_4>
            {
                new Column_4 { Value= "1.5",Y= 98.97f }
            };

            ICollection<Column_5> columns_5 = new List<Column_5>
            {
              new Column_5 { ImageSrc="/assets/images/Texture/arrow.png", Y= 98.97f, Y2=76.97f }
            };

            ICollection<Column_6> columns_6 = new List<Column_6>
            {
               new Column_6 { ImageSrc="/assets/images/Texture/1.png", Y= 100.4f, Y2=76.97f }
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
               new Column_9 {Value1=8, Value2=14, Value3=10, Y= 98.97f},
               new Column_9 {Value1=8, Value2=14, Value3=10, Y= 95.97f}
            };

            ICollection<Column_10> columns_10 = new List<Column_10>
            {
               new Column_10 { Value= "24", Y= 98.97f },
               new Column_10 { Value= "48", Y= 95.97f }
            };


            ICollection<Column_12> columns_12 = new List<Column_12>
            {
              new Column_12 { Value="01", Y= 98.97f, Length1=2.50f, Length2=2.80f }
            };

            ICollection<Column_11> columns_11 = new List<Column_11>
            {
               new Column_11 { Value="350", Y= 98.97f, Y2=95.97f,ColumnType=(int)ColumnType.PartOne },
               new Column_11 { Value="350", Y= 97.97f, Y2=93.97f,ColumnType=(int)ColumnType.PartTwo }
            };

            ICollection<Column_13> columns_13 = new List<Column_13>
            {
               new Column_13 { Value="60", Y= 98.97f, Y2=95.97f,ColumnType=(int)ColumnType.PartOne },
               new Column_13 { Value="70",  Y= 98.97f, Y2=95.97f,ColumnType=(int)ColumnType.PartTwo },
               new Column_13 { Value="100",  Y= 98.97f, Y2=95.97f,ColumnType=(int)ColumnType.PartThree },
               new Column_13 { Value="34", Y= 95.97f, Y2=93f,ColumnType=(int)ColumnType.PartOne },
               new Column_13 { Value="43", Y= 95.97f, Y2=93f,ColumnType=(int)ColumnType.PartTwo },
               new Column_13 { Value="-1",Y= 95.97f, Y2=93f,ColumnType=(int)ColumnType.PartThree },
               new Column_13 { Value="0", Y= 93f, Y2=88.97f,ColumnType=(int)ColumnType.PartOne },
               new Column_13 { Value="33", Y= 93f, Y2=88.97f,ColumnType=(int)ColumnType.PartTwo },
               new Column_13 { Value="100",  Y= 93f, Y2=88.97f,ColumnType=(int)ColumnType.PartThree },
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
                Columns_11 = columns_11,
                Columns_12 = columns_12,
                Columns_13 = columns_13,
                HeaderTemplateHtml = _templateRepository.GetHeaderHtml()
            };

            var json = JsonConvert.SerializeObject(pageCreationMember);

            return Json(json);
        }
    }
}