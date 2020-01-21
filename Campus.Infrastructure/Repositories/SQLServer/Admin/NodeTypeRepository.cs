using Campus.Data.SQLServer;
using Domain.Entities.Admin;
using Domain.IRepositories.SQLServer.Admin;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SQLServer.Admin
{
    public class NodeTypeRepository : INodeTypeRepository
    {
        private readonly CampusContext context;

        public NodeTypeRepository(CampusContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<NodeTypeEntity>> GetAllAsync()
        {
            return await context.NodeTypes.ToListAsync();
        }

        public async Task<NodeTypeEntity> GetByIdAsync(int id)
        {
            return await context.NodeTypes.FirstOrDefaultAsync(nodeType => nodeType.Id == id);
        }

        public async Task<NodeTypeEntity> GetByMachineNameAsync(string machineName)
        {
            return await context.NodeTypes.FirstOrDefaultAsync(nodeType => nodeType.MachineName == machineName);
        }

        public async Task<bool> CreateAsync(NodeTypeEntity model)
        {
            context.NodeTypes.Add(model);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(NodeTypeEntity model)
        {
            //NodeTypeEntity NodeType = await context.NodeTypes.FirstOrDefaultAsync(type => type.Id == id);

            //NodeType.Name = model.Name;
            //NodeType.Description = model.Description;
            //NodeType.Instructions = model.Instructions;

            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            context.NodeTypes.Remove(new NodeTypeEntity() { Id = id });

            await context.SaveChangesAsync();

            return true;
        }

        public bool NodeTypeExists(int id)
        {
            return context.NodeTypes.Any(e => e.Id == id);
        }
    }
}
