using System.ComponentModel.DataAnnotations;

namespace E_commarceWebApi.RequestModel
{
    public class CountrieDto
    {
        public string CountryName { get; set; }
        public List<string> CityNames { get; set; }
    }
}
