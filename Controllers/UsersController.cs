using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Entities;
using Microsoft.AspNetCore.Authorization;
using ERPNet.Services;
using ERPNet.Helpers;
using Microsoft.Extensions.Options;
using ERPNet.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ERPNet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        public UsersController(
            IUserService userService,
            IOptions<AppSettings> appSettings
            )
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost ( "authenticate" )]
        public IActionResult Authenticate ( [FromBody] AuthenticateModel model )
        {
            var user = _userService.Authenticate ( model.Username, model.Password );

            if(user == null)
                return BadRequest ( new { message = "Username or password is incorrect" } );

            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes ( _appSettings.Secret );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity ( new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return Ok ( user );
        }

        // GET: api/Users
        [Authorize ( Roles = Role.Admin )]
        [HttpGet]
        public IActionResult GetAll ( )
        {
            var users = _userService.GetAll ();
            return Ok ( users );
        }

        [HttpGet ( "{id}" )]
        public IActionResult GetById ( int id )
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse ( User.Identity.Name );
            if(id != currentUserId && !User.IsInRole ( Role.Admin ))
                return Forbid ();

            var user = _userService.GetById ( id );

            if(user == null)
                return NotFound ();

            return Ok ( user );
        }


        // PUT: api/Users/5
        [HttpPut ( "{id}" )]
        public IActionResult Update ( int id, [FromBody] AuthenticateModel model )
        {
            // map model to entity and set id
            //var user = _mapper.Map<User> ( model );
            var user = _userService.GetById ( id );
            user.Id = id;

            try
            {
                // update user 
                _userService.Update ( user, model.Password );
                return Ok ();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest ( new { message = ex.Message } );
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[AllowAnonymous]
        //[HttpPost ( "register" )]
        //public IActionResult Register ( [FromBody] RegisterModel model )
        //{
        //    // map model to entity
        //    var user = _mapper.Map<User> ( model );

        //    try
        //    {
        //        // create user
        //        _userService.Create ( user, model.Password );
        //        return Ok ();
        //    }
        //    catch(AppException ex)
        //    {
        //        // return error message if there was an exception
        //        return BadRequest ( new { message = ex.Message } );
        //    }
        //}

        // DELETE: api/Users/5
        [HttpDelete ( "{id}" )]
        public IActionResult Delete ( int id )
        {
            _userService.Delete ( id );
            return Ok ();
        }
    }
}
