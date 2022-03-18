using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Categories.Command.SimulationCategoriesCommand;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class UserAuthenticationCommandValidator : AbstractValidator<UserAuthenticationCommand>
    {
        const string CommandName = "Campo obrigatório";
        readonly DataContext _context;
        public UserAuthenticationCommandValidator(DataContext dataContext)
        {
            _context = dataContext;
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(CommandName);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(CommandName);

            RuleFor(x => x)
               .MustAsync(BeLoginAndPasswordTest)
               .WithMessage("Login ou senha inválidos");
        }

        public async Task<bool> BeLoginAndPasswordTest(UserAuthenticationCommand command, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(check => check.Login == command.UserName && check.Password == User.EncodingPassword(command.Password))
                .AnyAsync();
        }
    }

}
