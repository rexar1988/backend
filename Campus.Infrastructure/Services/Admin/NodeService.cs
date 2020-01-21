using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Admin;
using Domain.IRepositories.SQLServer.Admin;
using Domain.IServices.Admin;

namespace Infrastructure.Services.Admin
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository repository;

        public NodeService(INodeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<NodeEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<NodeEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(NodeEntity model)
        {
            return await repository.CreateAsync(model);
        }

        public async Task<bool> UpdateAsync(int id, NodeEntity model)
        {
            return await repository.UpdateAsync(id, model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
