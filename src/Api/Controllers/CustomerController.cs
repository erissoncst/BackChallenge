using Application.CheckIns.Command.SaveCheckIn;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        [HttpPost]
        public async Task<Customer> Save(SaveCustomerCommand command)
        {
            command.BirthDate = DateOnly.FromDateTime(DateTime.Now);
            return await Mediator.Send(command);
        }
    }
}