using AutoMapper;
using Domain.Entities.Admin;
using Domain.ViewModels.Admin.Node;
using Domain.IServices.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Campus.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    public class NodeController : Controller
    {
        private readonly INodeService service;
        private readonly IMapper mapper;

        public NodeController(INodeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>Get all items.</summary>
        /// <returns>Returns all items.</returns>
        /// <response code="200">Returns all items.</response>
        [HttpGet]
        [ProducesResponseType(typeof(NodeViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NodeViewModel>>> FindAllAsync()
        {
            IEnumerable<NodeEntity> Entries = await service.GetAllAsync();

            IEnumerable<NodeViewModel> Response = mapper.Map<IEnumerable<NodeEntity>, IEnumerable<NodeViewModel>>(Entries);

            return Ok(Response);
        }

        /// <summary>Get item by Id.</summary>
        /// <param name="id">Item Id.</param>
        /// <returns>Returns item according to the Id.</returns>
        /// <response code="200">Returns item according to the Id.</response>
        /// <response code="404">If the item is null.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NodeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NodeViewModel>> GetByIdAsync(int id)
        {
            NodeEntity Entry = await service.GetByIdAsync(id);

            if (Entry == null)
            {
                return NotFound();
            }

            NodeViewModel Response = mapper.Map<NodeEntity, NodeViewModel>(Entry);

            return Ok(Response);
        }

        /// <summary>Creates an item.</summary>
        /// <param name="model">Item model.</param>
        /// <returns>Returns item Id which has been created.</returns>
        /// <response code="200">Creates item and returns navigation Id which has been created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(NodeCreateViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateAsync([FromBody] NodeCreateViewModel model)
        {
            NodeEntity Request = mapper.Map<NodeCreateViewModel, NodeEntity>(model);

            return Ok(await service.CreateAsync(Request));
        }

        /// <summary>Updates an item.</summary>
        /// <param name="id">Item id.</param>
        /// <param name="model">Item model.</param>
        /// <returns>Returns empty response.</returns>
        /// <response code="204">Returns No Content for success update.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NodeUpdateViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] NodeUpdateViewModel model)
        {
            NodeEntity Entry = await service.GetByIdAsync(id);

            if (Entry == null)
            {
                return NotFound();
            }

            NodeEntity Request = mapper.Map<NodeUpdateViewModel, NodeEntity>(model);

            await service.UpdateAsync(id, Request);

            return NoContent();
        }

        /// <summary>Deletes a item.</summary>
        /// <param name="id">Item id.</param>
        /// <returns>Returns empty response.</returns>
        /// <response code="204">Returns No Content for success delete.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}