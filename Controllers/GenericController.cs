﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPNet.Data.Repositories;
using ERPNet.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPNet.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    public abstract class GenericController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {

        private readonly TRepository _repository;

        public GenericController ( TRepository repository )
        {
            this._repository = repository;
        }

        // GET: api/<GenericController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get ( )
        {
            return await _repository.GetAll ();
        }

        // GET api/<GenericController>/5
        [HttpGet ( "{id}" )]
        public async Task<ActionResult<TEntity>> Get ( int id )
        {
            var item = await _repository.Get ( id );

            if(item== null)
            {
                return NotFound ();
            }

            return item;
        }

        // POST api/<GenericController>
        [HttpPost]
        public void Post ( [FromBody] string value )
        {
        }

        // PUT api/<GenericController>/5
        [HttpPut ( "{id}" )]
        public void Put ( int id, [FromBody] string value )
        {
        }

        // DELETE api/<GenericController>/5
        [HttpDelete ( "{id}" )]
        public void Delete ( int id )
        {
        }
    }
}
