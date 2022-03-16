namespace Domain.Entities
{
    public class CheckInResponse
    {
        public String Base64 { get; set; }
        public CheckIn CheckIn { get; set; }

        public static CheckInResponse Of(String base64, CheckIn checkIn)
        {
            return new CheckInResponse 
            { 
                CheckIn = checkIn, 
                Base64=base64 
            };
        }
    }
}
