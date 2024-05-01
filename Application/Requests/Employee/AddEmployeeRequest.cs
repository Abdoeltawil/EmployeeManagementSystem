namespace Application.Requests.Employee
{
    public class AddEmployeeRequest
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
