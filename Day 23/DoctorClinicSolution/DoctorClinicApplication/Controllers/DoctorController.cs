using DoctorClinicApplication.Interface;
using DoctorClinicApplication.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService) {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var result = await _doctorService.GetAllDoctors();
                return Ok(result.ToList());
            }
            catch (Exception NoDoctorsFound) {
                return NotFound(NoDoctorsFound.Message);
            }
        }

        [HttpGet]
        [Route("GetDoctorBySpeciality")]
        public async Task<ActionResult<IList<Doctor>>> GetBySpeciality(string speciality)
        {
            try
            {
                var result = await _doctorService.GetDoctorBySpeciality(speciality);
                return Ok(result);
            }
            catch (Exception NoSuchDoctorFound) { 
                return NotFound(NoSuchDoctorFound.Message); 
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorExp(int key,int experience)
        {
            try
            {
                var result =await _doctorService.UpdateDoctorExperience(key, experience);
                return Ok(result);
            }
            catch(Exception NoSuchDoctorFound) {
                return NotFound(NoSuchDoctorFound.Message);
            }
        }
    }
}
