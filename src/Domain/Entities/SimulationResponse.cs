using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SimulationResponse
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Double Amount { get; set; }
        public Double AmountHours { get; set; }

        public static SimulationResponse Of(Simulation simulation, Category category)
        {
            var  start = simulation.Start;
            var end = simulation.End;
            var hours = (end - start).TotalHours;
            var amount = category.ValuePerHour * hours;
            return new SimulationResponse {
                Amount = amount, 
                End = end, 
                Start = start,
                AmountHours = hours
            };
        }

    }
}
