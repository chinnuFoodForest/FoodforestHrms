using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodForestMVC.Data;
using FoodForestMVC.Models;

namespace FoodForestMVC.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap(); 
        }
    }
}
