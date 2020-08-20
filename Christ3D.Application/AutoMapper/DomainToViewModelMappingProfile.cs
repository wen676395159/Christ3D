using AutoMapper;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(d=>d.Province,o=>o.MapFrom(s=>s.address.Province))
                .ForMember(d=>d.City,o=>o.MapFrom(s=>s.address.City))
                .ForMember(d=>d.County,o=>o.MapFrom(s=>s.address.County))
                .ForMember(d=>d.Street,o=>o.MapFrom(s=>s.address.Street));
            CreateMap<RegisterStudentCommand, StudentViewModel>()
                .ForMember(d => d.Province, o => o.MapFrom(s => s.address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.address.City))
                .ForMember(d => d.County, o => o.MapFrom(s => s.address.County))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.address.Street));
        }
    }
}
