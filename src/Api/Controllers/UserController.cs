using Application.Categories.Command.SimulationCategoriesCommand;
using Application.CheckIns.Command.SaveCheckIn;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost("Login")]
        public async Task<UserResponse> Save(UserAuthenticationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}