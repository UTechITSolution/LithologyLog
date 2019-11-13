using AutoMapper;
using LithologyLog.Model;
using LithologyLog.Web.Models;

namespace LithologyLog.Web.Helper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
             CreateMap<Organization, OrganizationCreateViewModel>().ReverseMap();
             CreateMap<Organization, OrganizationEditViewModel>().ReverseMap();
        }
    }
}
