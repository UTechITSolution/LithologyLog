using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LithologyLog.Model;
using LithologyLog.Repository;
using LithologyLog.Web.Lang;
using LithologyLog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LithologyLog.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private LocalizerService _localizerService;
        private readonly IMapper _mapper;

        public OrganizationController(IUnitOfWork unitOfWork,
                                      LocalizerService localizerService,
                                      IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _localizerService = localizerService;
            _mapper = mapper;
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

            var model = _unitOfWork.Repository<Organization>().Query().Select(x => new OrganizationList
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                MobileNumber = x.MobileNumber,
                Email = x.Email,
                Fax = x.Fax,
                TIN = x.TIN,
            });

            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.Name == searchValue
                                             || m.Name.StartsWith(searchValue));
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



        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(OrganizationCreateViewModel model)
        {
            var organization = _mapper.Map<Organization>(model);

            if (_unitOfWork.Repository<Organization>().Exist(x => x.Name == model.Name))
            {
                return Json(new { status = 207, message = _localizerService["AleadyTakenUsername"] });
            }

            var result = await _unitOfWork.Repository<Organization>().AddAsync(organization);

            if (result.IsSuccess)
            {
                return Json(new { status = 200, message = _localizerService["Success"] });
            }

            return Json(new { status = 406, message = _localizerService["Error"] });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _unitOfWork.Repository<Organization>().GetByIdAsync(id);

            var model = _mapper.Map<OrganizationEditViewModel>(organization);

            return PartialView("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit(OrganizationEditViewModel model)
        {
            var organization = _mapper.Map<Organization>(model);

            var result = await _unitOfWork.Repository<Organization>().UpdateAsync(organization);

            if (result.IsSuccess)
            {
                return Json(new { status = 200, message = _localizerService["Success"] });
            }

            return Json(new { status = 406, message = _localizerService["Error"] });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _unitOfWork.Repository<Organization>().GetByIdAsync(id);

            var result = await _unitOfWork.Repository<Organization>().DeleteAsync(organization);

            if (result.IsSuccess)
            {
                return Json(new { status = 200, message = _localizerService["Success"] });
            }

            return Json(new { status = 406, message = _localizerService["Error"] });
        }
    }
}