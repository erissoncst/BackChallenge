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
        public SaveCustomerCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.IndividualRegistration)
                .NotEmpty()
                .WithMessage(CommandName);
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage(CommandName);
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
    }

}
