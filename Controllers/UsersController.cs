using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ERPNet.Entities;
using Microsoft.AspNetCore.Authorization;
using ERPNet.Services;
using ERPNet.Helpers;
using Microsoft.Extensions.Options;
using ERPNet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ERPNet.Controllers
{
    [Authorize]
    [ApiController]
    [Route ( "api/[controller]" )]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings
            )
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost ( "authenticate" )]
        public IActionResult Authenticate ( [FromBody] AuthenticateModel model )
        {
            var user = _userService.Authenticate ( model.Username, model.Password );

            if(user == null)
                return BadRequest ( new { message = "Username or password is incorrect" } );

            return Ok ( user );

        }

        // GET: api/Users
        [Authorize ( Roles = Role.Admin )]
        [HttpGet]
        public IActionResult GetAll ( )
        {
            var users = _userService.GetAll ();
            var model = _mapper.Map<IList<UserModel>> ( users );
            return Ok ( model );
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

            var model = _mapper.Map<UserModel> ( user );
            return Ok ( model );

        }

        // POST: api/Users
        [AllowAnonymous]
        [Authorize ( Roles = Role.Admin )]
        [HttpPost ( "register" )]
        public IActionResult Register ( [FromBody] RegisterModel model )
        {
            // map model to entity
            var user = _mapper.Map<User> ( model );
            if(user.Role == Role.Admin)
            {
                user.Role = Role.Admin;
            }
            else
            {
                user.Role = Role.User;
            }
            try
            {
                // create user
                _userService.Create ( user, model.Password );
                return Ok ();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest ( new { message = ex.Message } );
            }
        }

        // PUT: api/Users/5
        [HttpPut ( "{id}" )]
        public IActionResult Update ( int id, [FromBody] UpdateModel model )
        {
            // map model to entity and set id
            var user = _mapper.Map<User> ( model );
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

        // DELETE: api/Users/5
        [HttpDelete ( "{id}" )]
        public IActionResult Delete ( int id )
        {
            _userService.Delete ( id );
            return Ok ();
        }

    }
}
