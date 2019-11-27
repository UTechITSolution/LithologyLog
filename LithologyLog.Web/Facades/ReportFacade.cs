using LithologyLog.Model;
using LithologyLog.Repository;
using LithologyLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Facades
{
    public interface IReportFacade
    {
        IQueryable<ReportList> GetAll();
    }

    public class ReportFacade : IReportFacade
    {
        private readonly IUnitOfWork _unitOfWork;


        public ReportFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<ReportList> GetAll()
        {
            var rows = from r in _unitOfWork.Repository<Report>().Query()
                       join cl in _unitOfWork.Repository<Organization>().Query() on r.ClientOrgId equals cl.Id
                       join co in _unitOfWork.Repository<Organization>().Query() on r.ClientOrgId equals co.Id
                       select new ReportList
                       {
                           Id = r.Id,
                           ProjectName = r.ProjectName,
                           SiteName = r.SiteName,
                           ClientOrg = cl.Name,
                           ContractorOrg = co.Name,
                       };

            return rows;

        }
    }
}
