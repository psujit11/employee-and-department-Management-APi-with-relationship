namespace MytemplateApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set;}

        public ICollection<Employee> Employees { get; set; }
    }
}
