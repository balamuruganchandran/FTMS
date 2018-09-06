using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.WebAPI.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.FTMS.WebAPI.Logic.Mapping
{
    public class DTOToEntityMapping : Profile
    {

        public DTOToEntityMapping()
        {
            CreateMap<AssignmentDTO, Assignment>();
            CreateMap<AssignmentAllocationDTO, AssignmentAllocation>();
            //  .ForMember(destination => destination.AssignmentStatus,
            //map => map.MapFrom(
            //source => new AssignmentStatus
            //{
            //    AssignmentStatusID = source.AssignmentStatusID,

            //    Name = source.AssignmentStatus

            //})).ForMember(destination => destination.AssignmentType,
            //  map => map.MapFrom(
            //  source => new AssignmentType
            //  {
            //      AssignmentTypeID = source.AssignmentTypeID,

            //      TypeName = source.AssignmentTypeName

            //  })).ForMember(destination => destination.Project,
            //  map => map.MapFrom(

            //  source => new Project
            //  {
            //      ProjectID = source.ProjectID,

            //      ProjectName = source.ProjectName
            //  })).ForMember(destination => destination.Practice,
            //  map => map.MapFrom(
            //  source => new Practice
            //  {
            //      PracticeID = source.PracticeID,

            //      Name = source.PracticeName

            //  })).ForMember(destination => destination.PeriodUnit,
            //  map => map.MapFrom(

            //  source => new PeriodUnit
            //  {
            //      PeriodUnitID = source.PeriodUnitID,

            //      PeriodName = source.PeriodUnitName
            //  }));
        }
    }
}

