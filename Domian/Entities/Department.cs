namespace Domian.Entities
{
    public class Department
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Details { set; get; }
        public int Order { set; get; }
        public bool IsActive { set; get; }
        public List<Employee> Employees { set; get; }

    }
}
