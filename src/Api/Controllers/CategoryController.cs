using Application.Categories.Command.SimulationCategoriesCommand;
using Application.Categories.Queries.ListCategories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await Mediator.Send(new ListCategoryQuery());
        }

        [HttpPost("{id}/Simulation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SimulationResponse))]
        public async Task<SimulationResponse> Simulation(Int64 id, [FromBody] Simulation simulation)
        {
            return await Mediator.Send(new SimulationCategoriesCommand(id, simulation));
        }
    }
}