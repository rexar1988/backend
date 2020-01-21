using Campus.Data.SQLServer;
using Domain.Entities.Admin;
using Domain.IRepositories.SQLServer.Admin;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SQLServer.Admin
{
    public class NodeRepository : INodeRepository
    {
        private readonly CampusContext context;

        public NodeRepository(CampusContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<NodeEntity>> GetAllAsync()
        {
            return await context.Nodes
                .Include(node => node.NodeType)
                .ToListAsync();
        }

        public async Task<NodeEntity> GetByIdAsync(int id)
        {
            return await context.Nodes
                .Include(node => node.NodeType)
                .FirstOrDefaultAsync(node => node.Id == id);
        }

        public async Task<int> CreateAsync(NodeEntity model)
        {
            context.Nodes.Add(model);

            await context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<bool> UpdateAsync(int id, NodeEntity model)
        {
            NodeEntity NodeType = await context.Nodes.FirstOrDefaultAsync(node => node.Id == id);

            NodeType.Title = model.Title;
            NodeType.Body = model.Body;
            NodeType.MetaTitle = model.MetaTitle;
            NodeType.MetaDescription = model.MetaDescription;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            context.Nodes.Remove(new NodeEntity() { Id = id });

            await context.SaveChangesAsync();

            return true;
        }
    }
}
