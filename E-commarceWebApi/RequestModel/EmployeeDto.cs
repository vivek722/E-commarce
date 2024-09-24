using System.ComponentModel.DataAnnotations;

namespace E_commarceWebApi.RequestModel
{
    public class EmployeeDto
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int DepartmentId { get; set; } 
        public int? ManagerId { get; set; } 

        public List<ProjectDto> EmpProject { get; set; } = new List<ProjectDto>(); 
    }
}
