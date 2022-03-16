using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Simulation
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static Simulation Of(DateTime Start, DateTime End)
        {
            return new Simulation
            {
                Start = Start,
                End = End
            };
        }
    }
}
