using AutoMapper;
using Domain.Entities.Admin;
using Domain.IServices.Admin;
using Domain.ViewModels.Admin.NodeType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Campus.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    public class NodeTypeController : Controller
    {
        private readonly INodeTypeService service;
        private readonly IMapper mapper;

        public NodeTypeController(INodeTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>Get all items.</summary>
        /// <returns>Returns all items.</returns>
        /// <response code="200">Returns all items.</response>
        [HttpGet]
        [ProducesResponseType(typeof(NodeTypeViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NodeTypeViewModel>>> GetAllAsync()
        {
            IEnumerable<NodeTypeEntity> Entries = await service.GetAllAsync();

            IEnumerable<NodeTypeViewModel> Response = mapper.Map<IEnumerable<NodeTypeEntity>, IEnumerable<NodeTypeViewModel>>(Entries);

            return Ok(Response);
        }

        /// <summary>Get item by Id.</summary>
        /// <param name="id">Item Id.</param>
        /// <returns>Returns item according to the Id.</returns>
        /// <response code="200">Returns item according to the Id.</response>
        /// <response code="404">If the item is null.</response>
        [HttpGet("{id}", Name = "GetByIdAsync")]
        [ProducesResponseType(typeof(NodeTypeViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NodeTypeViewModel>> GetByIdAsync(int id)
        {
            NodeTypeEntity Entry = await service.GetByIdAsync(id);

            if (Entry == null)
            {
                return NotFound();
            }

            NodeTypeViewModel Response = mapper.Map<NodeTypeEntity, NodeTypeViewModel>(Entry);

            return Ok(Response);
        }

        /// <summary>Get item by Machine Name.</summary>
        /// <param name="machineName">Machine Name field of item.</param>
        /// <returns>Returns item according to the Machine Name.</returns>
        /// <response code="200">Returns item according to the Machine Name.</response>
        /// <response code="404">If the item is null.</response>
        [HttpGet("machine-name/{machineName}")]
        [ProducesResponseType(typeof(NodeTypeShortViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NodeTypeShortViewModel>> GetByMachineNameAsync(string machineName)
        {
            NodeTypeEntity Entry = await service.GetByMachineNameAsync(machineName);

            if (Entry == null)
            {
                return NoContent();
            }

            NodeTypeShortViewModel Response = mapper.Map<NodeTypeEntity, NodeTypeShortViewModel>(Entry);

            return Ok(Response);
        }

        /// <summary>Creates an item.</summary>
        /// <param name="model">Item model.</param>
        /// <returns>Returns item Id which has been created.</returns>
        /// <response code="201">Creates item and returns navigation Id which has been created.</response>
        /// <response code="400">If item with the same Machine Name has already exist.</response>
        [HttpPost]
        [ProducesResponseType(typeof(NodeTypeCreateViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NodeTypeEntity>> CreateAsync([FromBody] NodeTypeCreateViewModel model)
        {
            NodeTypeEntity Entry = await service.GetByMachineNameAsync(model.MachineName);

            if (Entry != null)
            {
                return BadRequest();
            }

            NodeTypeEntity Request = mapper.Map<NodeTypeCreateViewModel, NodeTypeEntity>(model);

            await service.CreateAsync(Request);

            return CreatedAtRoute("GetByIdAsync", new { id = Request.Id }, new { id = Request.Id, name = Request.Name });
        }

        /// <summary>Updates an item.</summary>
        /// <param name="id">Item id.</param>
        /// <param name="model">Item model.</param>
        /// <returns>Returns empty response.</returns>
        /// <response code="204">Returns No Content for success update.</response>
        /// <response code="400">If Id in URI address does not match with id property in object in body.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NodeTypeUpdateViewModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] NodeTypeViewModel model)
        {
            NodeTypeEntity Request = mapper.Map<NodeTypeViewModel, NodeTypeEntity>(model);

            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                await service.UpdateAsync(Request);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.NodeTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>Deletes a item.</summary>
        /// <param name="id">Item id.</param>
        /// <returns>Returns empty response.</returns>
        /// <response code="204">Returns No Content for success delete.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (!service.NodeTypeExists(id))
            {
                return NotFound();
            }

            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}