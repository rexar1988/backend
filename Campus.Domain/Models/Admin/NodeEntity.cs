namespace Domain.Entities.Admin
{
    public class NodeEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Url { get; set; }

        public string Body { get; set; }

        public string MetaTitle { get; set; }
        
        public string MetaDescription { get; set; }

        public int NodeTypeId { get; set; }

        public NodeTypeEntity NodeType { get; set; }
    }
}
