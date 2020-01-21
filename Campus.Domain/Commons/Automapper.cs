using AutoMapper;
using Domain.Entities.Admin;
using Domain.ViewModels.Admin.Node;
using Domain.ViewModels.Admin.NodeType;

namespace Domain.Commons
{
    public class AutomapperMap : Profile
    {
        public AutomapperMap()
        {
            // Model to ViewModel
            CreateMap<NodeEntity, NodeViewModel>();

            CreateMap<NodeTypeEntity, NodeTypeViewModel>();
            CreateMap<NodeTypeEntity, NodeTypeShortViewModel>();

            // ViewModel to Model
            CreateMap<NodeTypeViewModel, NodeTypeEntity>();
            CreateMap<NodeTypeCreateViewModel, NodeTypeEntity>();
            CreateMap<NodeTypeUpdateViewModel, NodeTypeEntity>();

            CreateMap<NodeCreateViewModel, NodeEntity>();
            CreateMap<NodeUpdateViewModel, NodeEntity>();
        }

    }
}
