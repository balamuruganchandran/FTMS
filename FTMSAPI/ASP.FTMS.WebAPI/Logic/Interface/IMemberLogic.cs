using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.FTMS.WebAPI.Models.DTO;
using ASP.FTMS.API.Data.Models.Entity;

namespace ASP.FTMS.WebAPI.Logic.Interface
{
   public interface IMemberLogic
    {

        // int AddMember(MemberDTO memberDTO);
        int AddMember(MemberDTO member);
        IEnumerable<MemberDTO> GetAll();

        IEnumerable<MemberDTO> Get(int memberID);

        int UpdateMember(MemberDTO memberDTO);
        
         
    }
}
