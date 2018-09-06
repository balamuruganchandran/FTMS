using ASP.FTMS.API.Data.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.FTMS.API.Data.DAO.Interface
{
    public interface IMemberDAO
    {
        Task<int> AddMember(Member member);
        Task<IEnumerable<Member>> GetAll();

        Task<int> UpdateMember(Member member);
        Task<int> DeactivateMember(int memberID, string userName);
    }
}
