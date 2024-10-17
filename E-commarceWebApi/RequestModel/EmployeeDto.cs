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
        public List<ProjectDto> projects { get; set; }
    }
}
