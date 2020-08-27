namespace AccountExecutiveAPI.Models
{
    public class CompanyData
    {
        public string Company { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int ActiveTickets { get; set; }
        public int ActiveContracts { get; set; }
        public int Id { get; set; }
        public string AccountExecutive { get; set; }
    }
}