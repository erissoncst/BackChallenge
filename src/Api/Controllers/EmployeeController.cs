using Application.CheckIns.Command.SaveCheckIn;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "EMPLOYEE")]
        public async Task<Employee> Save(SaveEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}