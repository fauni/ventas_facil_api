using Core.Entities.Errors;
using Core.Entities.Login;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        ICompanyRepository _companyRepository;

        public UserController(IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            CodeErrorException error = null;
            var usuario = _userRepository.Login(user.UserName, user.PasswordHash, user.IdCompany, out error);
            var company = _companyRepository.GetCompanyByIdAsync(user.IdCompany);
            var resultSap = await _userRepository.AuthenticatedUserSap(new LoginRequestModel { CompanyDB = company.CompanyDB, UserName = company.UserName, Password = company.Password });
            try
            {
                if (error != null && !resultSap.isCorrect)
                {
                    return StatusCode(error.StatusCode, error);
                }
                else
                {
                    usuario.ApiToken = resultSap.SessionId;
                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }
    }
}
