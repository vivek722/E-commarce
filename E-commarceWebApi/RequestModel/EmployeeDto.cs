using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commarceWebApi.RequestModel
{
    public class EmployeeDto 
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDated { get; set; }
        public DateTime EndDate { get; set; }
    }
}
