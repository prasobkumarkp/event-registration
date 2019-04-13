namespace EventRegistration.Models
{
    public class BridgeRegistrationDay
    {
        public int DayId { get; set; }
        public Day Day { get; set; }

        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}
