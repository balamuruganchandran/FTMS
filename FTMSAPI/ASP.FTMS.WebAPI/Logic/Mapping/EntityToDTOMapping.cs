using ASP.FTMS.API.Data.DAO;
using ASP.FTMS.API.Data.Models.Entity;
using ASP.FTMS.WebAPI.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.FTMS.WebAPI.Logic.Mapping
{
    public class EntityToDTOMapping : Profile
    {
        AssignmentStatusDAO assignmentStatusDAO = new AssignmentStatusDAO();
        AssignmentTypeDAO assignmentTypeDAO = new AssignmentTypeDAO();
        PeriodUnitDAO periodUnitDAO = new PeriodUnitDAO();
        ProjectDAO projectDAO = new ProjectDAO();
        PracticeDAO practiceDAO = new PracticeDAO();
        public EntityToDTOMapping()
        {
            CreateMap<Assignment, AssignmentDTO>()
                  .ForMember(destination => destination.AssignmentStatus,
                  map => map.MapFrom(
                    src => assignmentStatusDAO.GetAssignmentStatusByAssignmentStatusId(src.AssignmentStatusID).Result.Name
                 )).ForMember(destination => destination.AssignmentTypeName,
                  map => map.MapFrom(
                    src => assignmentTypeDAO.GetAssignmentTypeByAssignmentTypeId(src.AssignmentTypeID).Result.TypeName
                 )).ForMember(destination => destination.PeriodUnitName,
                  map => map.MapFrom(
                    src => periodUnitDAO.GetPeriodUnitByPeriodUnitID(src.PeriodUnitID).Result.PeriodName
                 )).ForMember(destination => destination.ProjectName,
                  map => map.MapFrom(
                    src => projectDAO.GetProjectByProjectId(src.ProjectID).Result.ProjectName
                 ))
                 .ForMember(destination => destination.PracticeName,
                  map => map.MapFrom(
                    src => practiceDAO.GetPracticeByPracticeId(src.PracticeID).Result.PracticeID
                 ));



        }

    }
}