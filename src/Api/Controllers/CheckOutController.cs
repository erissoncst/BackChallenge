using Application.Categories.Command.SimulationCategoriesCommand;
using Application.Categories.Queries.ListCategories;
using Application.CheckIns.Command.SaveCheckIn;
using Application.CheckOuts.Command.SaveCheckIn;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CheckOutController : ApiControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "EMPLOYEE")]
        public async Task<CheckOut> Save(SaveCheckOutCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}