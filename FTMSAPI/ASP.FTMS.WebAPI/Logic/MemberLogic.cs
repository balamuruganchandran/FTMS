using System;
using System.Collections.Generic;
using ASP.FTMS.WebAPI.Logic.Interface;
using ASP.FTMS.WebAPI.Models.DTO;
using ASP.FTMS.API.Data.DAO;

namespace ASP.FTMS.WebAPI.Logic
{
    public class MemberLogic : IMemberLogic
    {
        MemberDAO memberDAO = new MemberDAO();

      

        public int AddMember(MemberDTO memberDTO)
        {

            //conversionM
           
         //Mapper.CreateMap<MemberDTO,Member>()  .ForMember(destination => destination.Batch,

         //     map => map.MapFrom(

         //         source => new Batch

         //         {

         //             BatchID = source.BatchID,

         //             BatchName = source.BatchName

         //         })).ForMember(destination => destination.Batch,
         //         map => map.MapFrom(

         //         source => new Practice

         //         {

         //             PracticeID = source.PracticeID,

         //             Name = source.PracticeName

         //         })).ForMember(destination => destination.Batch,
         //         map => map.MapFrom(

         //         source => new Roles

         //         {

         //             RoleID = source.RoleID,

         //             RoleName = source.RoleName

         //         }));
        
         //   Member member = Mapper.Map<MemberDTO, Member>(memberDTO);
         //    //   Task<int> Id=memberDAO.AddMember(memberDTO);
            return 1;

        }

        public IEnumerable<MemberDTO> Get(int memberID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public int UpdateMember(MemberDTO member)
        {
            throw new NotImplementedException();
        }
    }
}