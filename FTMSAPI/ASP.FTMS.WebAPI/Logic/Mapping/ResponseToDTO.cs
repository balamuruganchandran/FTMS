using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.API.Data.Models.Response;
using ASP.FTMS.WebAPI.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.FTMS.WebAPI.Logic.Mapping
{
    public class ResponseToDTO:Profile
    {
        public ResponseToDTO()
        {
            CreateMap<AssignmentDetails, AssignmentDTO>();                              
        }
    }
}