using Domain.Entities.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories.SQLServer.Admin
{
    public interface INodeTypeRepository
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
