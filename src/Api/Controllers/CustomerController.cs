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
            return await Mediator.Send(command);
        }
    }
}