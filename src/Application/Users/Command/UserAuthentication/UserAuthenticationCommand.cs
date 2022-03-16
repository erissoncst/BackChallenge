using Application.Common.Exceptions;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.SimulationCategoriesCommand
{
    public class UserAuthenticationCommand : IRequest<UserResponse>
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }

    public class UserAuthenticationCommandHandler : IRequestHandler<UserAuthenticationCommand, UserResponse>
    {
        private readonly DataContext _context;

        public UserAuthenticationCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<UserResponse> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
            var password = User.EncodingPassword(request.Password);
            var user = _context.Users
                .Include(u => u.Employee)
                .Include(u => u.Customer)
                .Where(cat => cat.Login == request.UserName && cat.Password == password)
                .FirstOrDefault();

            return UserResponse.Of(User.GenerateToken(user), user);

        }
    }
}
