using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using student.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        [HttpPost]
        public ActionResult Login(LoginDTO model)
        {
            // Kiểm tra tính hợp lệ của mô hình dữ liệu
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }

            // Tạo đối tượng phản hồi đăng nhập
            LoginResponseDTO loginResponseDTO = new() { Username = model.Username };

            // Kiểm tra thông tin đăng nhập
            if (model.Username == "string" && model.Password == "string")
            {
                // Lấy khóa bí mật từ cấu hình
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecrret")!);
                var issuer = _configuration.GetValue<string>("LocalIssuer");
                var audience = _configuration.GetValue<string>("LocalAudience");
                // Tạo bộ xử lý token
                var tokenHandler = new JwtSecurityTokenHandler();

                // Mô tả token
                var tokenDes = new SecurityTokenDescriptor()
                {
                    Issuer = issuer,
                    Audience = audience,
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Name, model.Username),
                            new Claim(ClaimTypes.Role, "Admin"),
                        }),
                    Expires = DateTime.Now.AddHours(4), // Thời gian hết hạn của token
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256) // Chữ ký token
                };

                // Tạo token
                var token = tokenHandler.CreateToken(tokenDes);

                // Ghi token vào đối tượng phản hồi
                loginResponseDTO.Token = tokenHandler.WriteToken(token);
            }
            else
            {
                // Nếu thông tin đăng nhập không hợp lệ, trả về phản hồi rỗng
                return Ok("");
            }

            // Trả về đối tượng phản hồi đăng nhập với token
            return Ok(loginResponseDTO);
        }

    }


}
