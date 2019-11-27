using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LithologyLog.Model;
using LithologyLog.Repository;
using LithologyLog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LithologyLog.Web.Controllers
{
    public class DropDownController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public DropDownController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public JsonResult Organization(string search)
        {
            List<DropDownViewModel> list = null;

            if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
            {
                list = _unitOfWork.Repository<Organization>().Query().
                         Where(x => x.Name.ToLower().StartsWith(search.ToLower()))
                         .Select(x => new DropDownViewModel
                         {
                             text = x.Name,
                             id = x.Id
                         }).ToList();
            }

            return Json(new { items = list });

        }
    }
}