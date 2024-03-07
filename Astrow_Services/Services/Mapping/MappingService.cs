using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astrow_Domain.Models;
using AutoMapper;
using Astrow.Shared.DTO;
using Astrow_Services.Interfaces;

namespace Astrow_Services.Services.Mapping
{
    public class MappingService 
    {
        public readonly AutoMapper.IMapper _mapper;
        public MappingService() 
        {
            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teachers, TeacherDTO>();
                cfg.CreateMap<TeacherDTO, Teachers>();
                cfg.CreateMap<Students, StudentDTO>();
                cfg.CreateMap<StudentDTO, Students>();
            });

            try
            {
                _mapper = config.CreateMapper();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to create map {ex.Message}");
                throw;
            }
        }
        
    }
}
