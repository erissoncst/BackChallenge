using Application.Common.Reports;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckIns.Command.SaveCheckIn

{
    public class SaveCheckInsCommand : IRequest<CheckInResponse>
    {
        public Int64 ModelId { get; set; }
        public Int64 CustomerId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class SaveCheckInsCommandHandler : IRequestHandler<SaveCheckInsCommand, CheckInResponse>
    {
        private readonly DataContext _dataContext;

        public SaveCheckInsCommandHandler(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<CheckInResponse> Handle(SaveCheckInsCommand request, CancellationToken cancellationToken)
        {
            var cars = _dataContext.Cars
                .Include(car => car.Model)
                .Include(car => car.Model.Category)
                .Include(car => car.Model.Brand)
                .Include(car => car.CheckIns)
                .Where(car => car.Model.ModelId == request.ModelId && !car.CheckIns.Where(check => check.RentCarType == RentCarType.ACTIVE).Select(check => check.CarId).Contains(car.CarId))
                .ToList();

            var car = cars.First();
            var simulation = SimulationResponse.Of(Simulation.Of(request.Start, request.End), car.Model.Category);
            var checkin = CheckIn.Of(car, request.CustomerId, RentCarType.ACTIVE, simulation);
            _dataContext.CheckIns.Add(checkin);
            _dataContext.SaveChanges();
            var newRent = _dataContext.CheckIns
                .Include(check => check.Car)
                .Include(check => check.Car.Model)
                .Include(check => check.Car.Model.Brand)
                .Include(check => check.Customer)
                .Where(check => check.CheckInId == checkin.CheckInId).FirstOrDefault();

            return CheckInResponse.Of(Reports.BuildContract(newRent), newRent);
        }
    }
}
