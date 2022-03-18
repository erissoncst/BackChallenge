using Application.Common.Reports;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveCustomerCommand : IRequest<Customer>
    {
        public String Password { get; set; }
        public String FullName { get; set; }
        public String IndividualRegistration { get; set; }
        public String BirthDate { get; set; }
        public String ZipCode { get; set; }
        public String PublicPlace { get; set; }
        public String Number { get; set; }
        public String? Complement { get; set; }
        public String City { get; set; }
        public String State { get; set; }
    }

    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, Customer>
    {
        private readonly DataContext _dataContext;

        public SaveCustomerCommandHandler(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Customer> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            var user = User.Of(request.IndividualRegistration, User.EncodingPassword(request.Password));
            _dataContext.Users.Add(user);
            
            var customer = Customer.Of(request.FullName, 
                request.IndividualRegistration,
                DateOnly.Parse(request.BirthDate),
                request.ZipCode,
                request.PublicPlace,
                request.Number,
                request.Complement,
                request.City,
                request.State,
                user);
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
            return customer;
        }
    }
}
