using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Command.SimulationCategoriesCommand
{
    public class SimulationCategoriesCommand : IRequest<SimulationResponse>
    {
        public Int64 CategoryId { get; set; }
        public Simulation Simulation { get; set; }

        public SimulationCategoriesCommand(Int64 category, Simulation simulation)
        {
            CategoryId = category;
            Simulation = simulation;
        }
    }

    public class SimulationCategoriesCommandHandler : IRequestHandler<SimulationCategoriesCommand, SimulationResponse>
    {
        private readonly DataContext _context;

        public SimulationCategoriesCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<SimulationResponse> Handle(SimulationCategoriesCommand request, CancellationToken cancellationToken)
        {
            var simulation = request.Simulation;
            var category = _context.Categories.Where(cat => cat.CategoryId == request.CategoryId).First();
   
            return SimulationResponse.Of(simulation, category);
        }
    }
}
