using AutoMapper;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Application.AutoMapper
{
    public class ViewModelsToDomainMappingProfile : Profile
    {
        public ViewModelsToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForPath(d => d.address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.address.City, o => o.MapFrom(s => s.City))
                .ForPath(d => d.address.County, o => o.MapFrom(s => s.County))
                .ForPath(d => d.address.Street, o => o.MapFrom(s => s.Street));

            CreateMap<StudentViewModel, RegisterStudentCommand>()
                .ForPath(d => d.address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.address.City, o => o.MapFrom(s => s.City))
                .ForPath(d => d.address.County, o => o.MapFrom(s => s.County))
                .ForPath(d => d.address.Street, o => o.MapFrom(s => s.Street));
        }
    }
}
