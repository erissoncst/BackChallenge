using Application.Categories.Command.SimulationCategoriesCommand;
using Application.Categories.Queries.ListCategories;
using Application.CheckIns.Command.SaveCheckIn;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CheckInController : ApiControllerBase
    {
        [HttpPost]
        public async Task<CheckInResponse> Save(SaveCheckInsCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}