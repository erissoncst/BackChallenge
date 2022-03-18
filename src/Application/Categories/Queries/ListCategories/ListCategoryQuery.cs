using MediatR;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.ListCategories
{
    public class ListCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }

    public class ListCategoryQueryHandler : IRequestHandler<ListCategoryQuery, IEnumerable<Category>>
    {
        private readonly DataContext _dataContext;

        public ListCategoryQueryHandler(DataContext context)
        {
            _dataContext = context;
        }

        public Task<IEnumerable<Category>> Handle(ListCategoryQuery request, CancellationToken cancellationToken) 
        {
            var records =  _dataContext.Categories.Include(cat => cat.Models).ToList().Select(cat => {
                cat.Models = cat.Models.ToList().Select(model =>
                {
                    model.Cars = _dataContext.Cars
                    .Include(car => car.Model)
                    .Include(car => car.Model.Category)
                    .Include(car => car.Model.Brand)
                    .Include(car => car.CheckIns)
                    .Where(car => car.Model.ModelId == model.ModelId && !car.CheckIns.Where(rent => rent.RentCarType == RentCarType.ACTIVE).Select(rent => rent.CarId).Contains(car.CarId))
                    .ToList();
                    
                    return model;
                });
                return cat;
            });
            return Task.FromResult(records);
        }
    }
}
