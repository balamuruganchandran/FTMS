using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ASP.FTMS.WebAPI.Logic;
using ASP.FTMS.WebAPI.Logic.Mapping;

namespace ASP.FTMS.WebAPI.App_Start
{
    public static class AutoMapperConfiguration
    {

        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DTOToEntityMapping>();

                x.AddProfile<EntityToDTOMapping>();

                x.AddProfile<ResponseToDTO>();
            });


        }
    }
}
