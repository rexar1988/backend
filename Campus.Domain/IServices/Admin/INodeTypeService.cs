using Domain.Entities.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IServices.Admin
{
    public interface INodeTypeService
    {
        Task<IEnumerable<NodeTypeEntity>> GetAllAsync();

        Task<NodeTypeEntity> GetByIdAsync(int id);

        Task<NodeTypeEntity> GetByMachineNameAsync(string machineName);

        Task<bool> CreateAsync(NodeTypeEntity model);

        Task<bool> UpdateAsync(NodeTypeEntity model);

        Task<bool> DeleteAsync(int id);

        bool NodeTypeExists(int id);
    }
}
