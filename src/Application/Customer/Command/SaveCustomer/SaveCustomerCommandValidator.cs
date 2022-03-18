using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveCustomerCommandValidator : AbstractValidator<SaveCustomerCommand>
    {
        const string CommandName = "Campo obrigatório";
        readonly DataContext _context;
        public SaveCustomerCommandValidator(DataContext context)
        {
            _context = context;
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.IndividualRegistration)
                .NotEmpty()
                .WithMessage(CommandName)
                .MustAsync(BeUniqueLogin)
                .WithMessage("Existe usuário com esse CPF.")
                .MustAsync(BeUniqueRegistration)
                .WithMessage("CPF já cadastrado.");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage(CommandName)
                .MustAsync(BeValidDate)
                .WithMessage("Data inválida");
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.PublicPlace)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(CommandName);
        }

        public async Task<bool> BeValidDate(String dateTime, CancellationToken cancellationToken)
        {
            DateOnly res;
            return DateOnly.TryParse(dateTime, out res);
        }

        public async Task<bool> BeUniqueLogin(String login, CancellationToken cancellationToken)
        {
            return !await _context.Users.Where(c=>c.Login == login).AnyAsync();
        }
        public async Task<bool> BeUniqueRegistration(String registration, CancellationToken cancellationToken)
        {
            return !await _context.Customers.Where(c => c.IndividualRegistration == registration).AnyAsync();
        }
    }
}
