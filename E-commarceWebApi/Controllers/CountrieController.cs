using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.services.User;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class CountrieController : Controller
    {
        private readonly ICountrieService _countrieService;
        private readonly IMapper _mapper;
        public CountrieController(ICountrieService countrieService, IMapper mapper)
        {
            _countrieService = countrieService;
            _mapper = mapper;
        }
        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries(string? SerchString)
        {
            if (SerchString == null)
            {
                var roles = await _countrieService.GetAll();
                return Ok(roles);
            }
            var Searchroles = await _countrieService.SearchCountries(SerchString);
            return Ok(Searchroles);
        }
        [HttpPost("AddCountries")]
        public async Task<IActionResult> AddCountries([FromForm]CountrieDto Countries)
        {
            if (ModelState.IsValid)
            {
                var countrie = _mapper.Map<Countrie>(Countries);
                if (countrie != null)
                {
                    await _countrieService.Add(countrie);
                    return Ok(countrie);
                }
            }
            return BadRequest("Data Is Not Proper");
        }
        [HttpDelete("DeleteCountrie")]
        public async Task<IActionResult> DeleteCountrie(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Is Not  0 or Lessthen 0");
            }
            await _countrieService.Delete(id);
            return Ok("Role Deleted Successfully");
        }
        [HttpPut("UpdateCountrie")]
        public async Task<IActionResult> UpdateCountrie(CountrieDto Countrie)
        {
            if (ModelState.IsValid)
            {
                Countrie countries = new Countrie();
                countries.CountryName = Countrie.CountryName;
                if (countries != null)
                {
                    await _countrieService.update(countries);
                    return Ok("Role Updated Successfully");
                }
            }
            return BadRequest("Data Is Not Proper");
        }
    }
}
