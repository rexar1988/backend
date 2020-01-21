using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels.Admin.Node
{
    public class NodeCreateViewModel
    {
        public string Title { get; set; }
        
        public string Url { get; set; }

        public string Body { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public int NodeTypeId { get; set; }
    }
}
