namespace EmployeeManagementSystem.DataAccess.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int EmployeeId { get; set; }
        public string Type { get; set; }
    }
}
