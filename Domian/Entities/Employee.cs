﻿namespace Domian.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
