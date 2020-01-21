using Domain.Entities.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IServices.Admin
{
    public interface INodeService
    {
        Task<IEnumerable<NodeEntity>> GetAllAsync();

        Task<NodeEntity> GetByIdAsync(int id);
        
        Task<int> CreateAsync(NodeEntity model);

        Task<bool> UpdateAsync(int id, NodeEntity model);

        Task<bool> DeleteAsync(int id);
    }
}
