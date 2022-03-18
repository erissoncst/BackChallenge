using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckOuts.Command.SaveCheckIn

{
    public class SaveCheckOutCommandValidator : AbstractValidator<SaveCheckOutCommand> {

        private readonly DataContext _context;

        public SaveCheckOutCommandValidator(DataContext context)
        {
            _context = context;
            RuleFor(x => x.CheckinId)
                .NotEmpty()
                .WithMessage("CheckIn não informado")
                .MustAsync(BeUniqueCheckIn)
                .WithMessage("CheckOut já cadastrado")
                .MustAsync(BeCheckInExist)
                .WithMessage("CheckIn não cadastrado");
            RuleFor(x => x.CleanCar).NotNull().WithMessage("É necessário enviar o status do item");
            RuleFor(x => x.FullTank).NotNull().WithMessage("É necessário enviar o status do item");
            RuleFor(x => x.NoDents).NotNull().WithMessage("É necessário enviar o status do item");
            RuleFor(x => x.NoScratches).NotNull().WithMessage("É necessário enviar o status do item");
        }

        public async Task<bool> BeUniqueCheckIn(Int64 checkinId, CancellationToken cancellationToken)
        {
            return !await _context.CheckOuts
                .Where(check => check.CheckinId == checkinId)
                .AnyAsync();
        }

        public async Task<bool> BeCheckInExist(Int64 checkinId, CancellationToken cancellationToken)
        {
            return await _context.CheckIns
                .Where(check => check.CheckInId == checkinId)
                .AnyAsync();
        }
    }

}
