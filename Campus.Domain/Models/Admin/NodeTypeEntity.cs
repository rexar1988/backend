using System.Collections.Generic;

namespace Domain.Entities.Admin
{
    public class NodeTypeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MachineName { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public ICollection<NodeEntity> Nodes { get; set; }
    }
}
