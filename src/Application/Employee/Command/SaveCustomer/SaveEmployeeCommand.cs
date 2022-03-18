using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveEmployeeCommand : IRequest<Employee>
    {
        public String Password { get; set; }
        public String FullName { get; set; }
        public String Registration { get; set; }
    }

    public class SaveEmployeeCommandHandler : IRequestHandler<SaveEmployeeCommand, Employee>
    {
        private readonly DataContext _dataContext;

        public SaveEmployeeCommandHandler(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Employee> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = User.Of(request.Registration, User.EncodingPassword(request.Password));
            _dataContext.Users.Add(user);
            Employee customer = Employee.Of(request.FullName,
                request.Registration,
                user);
            _dataContext.Employees.Add(customer);
            _dataContext.SaveChanges();
            return customer;
        }
    }
}
