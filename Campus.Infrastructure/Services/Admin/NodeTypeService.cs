using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Admin;
using Domain.IRepositories.SQLServer.Admin;
using Domain.IServices.Admin;

namespace Infrastructure.Services.Admin
{
    public class NodeTypeService : INodeTypeService
    {
        private readonly INodeTypeRepository repository;

        public NodeTypeService(INodeTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<NodeTypeEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<NodeTypeEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<NodeTypeEntity> GetByMachineNameAsync(string machineName)
        {
            return await repository.GetByMachineNameAsync(machineName);
        }

        public async Task<bool> CreateAsync(NodeTypeEntity model)
        {
            return await repository.CreateAsync(model);
        }

        public async Task<bool> UpdateAsync(NodeTypeEntity model)
        {
            return await repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public bool NodeTypeExists(int id)
        {
            return repository.NodeTypeExists(id);
        }
    }
}
