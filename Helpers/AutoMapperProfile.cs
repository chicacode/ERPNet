using AutoMapper;
using ERPNet.Entities;
using ERPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile ( )
        {
            CreateMap<User, UserModel> ();
            CreateMap<RegisterModel, User> ();
            CreateMap<UpdateModel, User> ();
        }
    }
}
