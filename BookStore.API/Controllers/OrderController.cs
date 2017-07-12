using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Entities;
using BookStore.Repositories;

namespace BookStore.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        // GET api/<controller>
        //public ICollection<Order> Get()
        //{
        //    return _unitOfWork.OrderRepository.GetAll();
        //}

        // GET api/<controller>/5
        public Order Get(int id)
        {
            return _unitOfWork.OrderRepository.Find(id);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Order value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _unitOfWork.OrderRepository.Create(value);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Order value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }
                value.Id = id;
                _unitOfWork.OrderRepository.Update(value);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}