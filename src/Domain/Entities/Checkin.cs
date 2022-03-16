using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("checkins")]
    public class CheckIn
    {
        [Key]
        [Column("checkin_id")]
        public Int64 CheckInId { get; set; }

        [Column("car_id")]
        public Int64 CarId { get; set; }
        public Car Car { get; set; }

        [Column("customer_id")]
        public Int64 CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column("rentcar_type")]
        public RentCarType RentCarType { get; set; }

        [Column("total_paid")]
        public Double? TotalPaid { get; set; }

        [Column("contract_value")]
        public Double ContractValue { get; set; }

        [Column("start")]
        public DateTime Start { get; set; }
       
        [Column("end")]
        public DateTime End { get; set; }

        public static CheckIn Of(Car car, Customer customer, Double contractValue, RentCarType rentCarType, DateTime start, DateTime end)
        {
            return new CheckIn 
            { 
                Car = car, 
                Customer = customer, 
                RentCarType = rentCarType, 
                Start = start, 
                End = end,
                ContractValue = contractValue
            };
        }

        public static CheckIn Of(Car car, Int64 customerId, RentCarType type, SimulationResponse simulation)
        {
            return new CheckIn
            {
                Car = car,
                CustomerId = customerId,
                RentCarType = type,
                Start = simulation.Start,
                End = simulation.End,
                ContractValue = simulation.Amount,
            };
        }
    }
}
