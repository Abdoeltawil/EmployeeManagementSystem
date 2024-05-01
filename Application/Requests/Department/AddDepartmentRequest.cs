namespace Application.Requests.Department
{
    public class AddDepartmentRequest
    {
        public string Name { set; get; }
        public string Details { set; get; }
        public int Order { set; get; }
        public bool IsActive { set; get; }
    }
}
