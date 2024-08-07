using AutoMapper;
using PatientManagement.Data;
using PatientManagement.Migrations;
using PatientManagement.Models;

namespace PatientManagement.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        { 
            CreateMap<Patient,Patient>().ReverseMap();
        }
    }
}
