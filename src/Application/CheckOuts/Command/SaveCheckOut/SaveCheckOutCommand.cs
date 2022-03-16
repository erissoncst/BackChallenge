using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CheckOuts.Command.SaveCheckIn

{
    public class SaveCheckOutCommand : IRequest<CheckOut>
    {
        public Int64 CheckinId { get; set; }
        public Boolean CleanCar { get; set; }
        public Boolean FullTank { get; set; }
        public Boolean NoDents { get; set; }
        public Boolean NoScratches { get; set; }
    }

    public class SaveCheckInCommandHandler : IRequestHandler<SaveCheckOutCommand, CheckOut>
    {
        private readonly DataContext _dataContext;

        public SaveCheckInCommandHandler(DataContext context)
        {
            _dataContext = context;
        }

        internal Double Addition(Double total)
        {
            return total + (total * .3);
        }

        public async Task<CheckOut> Handle(SaveCheckOutCommand request, CancellationToken cancellationToken)
        {
            var checkIn = _dataContext
                .CheckIns.Where(checkin => checkin.CheckInId == request.CheckinId).First();
            var totalPaid = checkIn.ContractValue;

            if (!request.CleanCar)
            {
                totalPaid = Addition(totalPaid);
            }
            if (!request.FullTank)
            {
                totalPaid = Addition(totalPaid);
            }
            if (!request.NoDents)
            {
                totalPaid = Addition(totalPaid);
            }
            if (!request.NoScratches)
            {
                totalPaid = Addition(totalPaid);
            }
            checkIn.TotalPaid = totalPaid;
            var checkOut = new CheckOut
            {
                CheckIn = checkIn,
                CleanCar = request.CleanCar,
                FullTank = request.FullTank,
                NoDents = request.NoDents,
                NoScratches = request.NoScratches,
            };
            _dataContext.CheckOuts.Add(checkOut);
            _dataContext.SaveChanges();
            return checkOut;
        }
    }
}
