using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.TicketShop.Api.Services;
using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;

namespace Spg.TicketShop.Api.Controllers
{
    /// <summary>
    /// Controller-Klasse, die sich um das Einloggen des Users kümmert.
    /// LogOut gibt es nicht. Das liegt daran, dass der JWT-Token ja am 
    /// Client gespeichert bleibt und in jedem HTTP-Request an die API
    /// (im HTTP-Header) mitgegeben wird. Solange der Token existiert
    /// und mitgegeben wird, ist man eingeloggt.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // private Field, welches die Service-Instanz beinhaltet.
        private readonly UserService _userService;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="userService">
        /// Wird über Dependency Injection durch services.AddScoped() in ConfigureServices() übergeben.
        /// Siehe <see cref="Spg.TicketShop.Api.Extensions.HostingExtensions"/>.
        /// </param>
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// POST Route für http://.../api/user/login
        /// </summary>
        /// <param name="user">User aus dem HTTP Request Body (RAW, Content type: JSON)</param>
        /// <returns>Token als String oder BadRequest wenn der Benutzer nicht angemeldet werden konnte.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserDto user)
        {
            try
            {
                string token = _userService.GenerateToken(user);
                if (token != null)
                {
                    user.Token = token;
                    return Ok(user);
                }
                return Unauthorized(new { message = "EMail/Username oder Kennwort sind nicht korrekt!" });
            }
            catch (ServiceException)
            {
                //TODO: Exception-Logging/Tracing
                return BadRequest();
            }
        }
    }
}