using Domain.ViewModels.Admin.NodeType;

namespace Domain.ViewModels.Admin.Node
{
    public class NodeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Body { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public NodeTypeShortViewModel NodeType { get; set; }
    }
}
