namespace ITSMCodingTest.Models
{
    public class Flag
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }
    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }
    public class RestCountry
    {
        public Name Name { get; set; }
        public string cca3 { get; set; }
        public Flag Flags { get; set; }
    }
}