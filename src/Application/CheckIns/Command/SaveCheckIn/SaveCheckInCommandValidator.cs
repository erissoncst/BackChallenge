using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveCheckOutCommandValidator : AbstractValidator<SaveCheckInsCommand>
    {
        private readonly DataContext _context;

        public SaveCheckOutCommandValidator(DataContext context)
        {
            _context = context;

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Cliente não informado")
                .MustAsync(BeCustomerIdExist)
                .WithMessage("Cliente não cadastrado"); ;
            RuleFor(x => x.ModelId)
                .NotEmpty()
                .WithMessage("Modelo não informado")
                .MustAsync(BeAvailableCars)
                .WithMessage("Nenhum carro desse modelo está disponível no momento");
            RuleFor(x => x.End)
                .GreaterThan(x => x.Start)
                .WithMessage("A data final não pode ser maior ou igual a data inicial");
            RuleFor(x => (x.End - x.Start).TotalHours)
                .GreaterThan(1)
                .WithMessage("O tempo mínimo é de 1 hora");
        }

        public async Task<bool> BeAvailableCars(Int64 modelId, CancellationToken cancellationToken)
        {
            return await _context.Cars
                .Include(car => car.Model)
                .Include(car => car.CheckIns)
                .Where(car => car.Model.ModelId == modelId && !car.CheckIns.Where(rent => rent.RentCarType == RentCarType.ACTIVE).Select(rent => rent.CarId).Contains(car.CarId))
                .AnyAsync();
        }

        public async Task<bool> BeCustomerIdExist(Int64 customerId, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .Where(check => check.CustomerId == customerId)
                .AnyAsync();
        }
    }

}
