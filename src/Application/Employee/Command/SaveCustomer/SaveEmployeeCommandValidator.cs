using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeCommand>
    {
        const string CommandName = "Campo obrigatório";
        readonly DataContext _dataContext;
        public SaveEmployeeCommandValidator(DataContext context)
        {
            _dataContext = context;
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.Registration)
                .NotEmpty()
                .WithMessage(CommandName)
                .MustAsync(BeUniqueLogin)
                .WithMessage("Existe usuário com essa matrícula.")
                .MustAsync(BeUniqueRegistration)
                .WithMessage("Matrícula já cadastrada."); ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(CommandName);
        }

        public async Task<bool> BeUniqueLogin(String login, CancellationToken cancellationToken)
        {
            return !await _dataContext.Users.Where(c => c.Login == login).AnyAsync();
        }
        public async Task<bool> BeUniqueRegistration(String registration, CancellationToken cancellationToken)
        {
            return !await _dataContext.Employees.Where(c => c.Registration == registration).AnyAsync();
        }
    }

}
