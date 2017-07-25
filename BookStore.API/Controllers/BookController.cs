using BookStore.Entities;
using BookStore.Repositories;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// Represents books
    /// </summary>
    public class BookController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        
        // GET api/<controller>
        /// <summary>
        /// Returns list of books
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<Book>))]
        public IEnumerable<Book> Get()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        // GET api/<controller>/5
        /// <summary>
        /// Returns book by id
        /// </summary>
        /// <param name="id">book identifier</param>
        /// <returns></returns>
        [ResponseType(typeof(Book))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Book), Description = "Not found: book with this id is not found")]
        public IHttpActionResult Get(int id)
        {
            var book = _unitOfWork.BookRepository.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<controller>
        /// <summary>
        /// Crates book 
        /// </summary>
        /// <param name="value">book model</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request: book model is invalid")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "OK: book created")]
        public IHttpActionResult Post([FromBody]Book value)
        {
            try
            {
                _unitOfWork.BookRepository.Create(value);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Updates book with following id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <param name="value">book model</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request: book with this id is not exist or book model is not valid")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Ok: book successfully updated")]
        public IHttpActionResult Put(int id, [FromBody]Book value)
        {
            try
            {
                var book = _unitOfWork.BookRepository.Find(id);
                book.Name = value.Name;
                book.Price = value.Price;
                book.Year = value.Year;
                var author = _unitOfWork.AuthorRepository.Find(value.Author.Id);
                book.Author = author ?? value.Author;
                _unitOfWork.BookRepository.Update(book);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Deletes book
        /// </summary>
        /// <param name="id">book identifier</param>
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not found: book with this id is not found")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Ok: book is deleted")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.BookRepository.Delete(id);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}