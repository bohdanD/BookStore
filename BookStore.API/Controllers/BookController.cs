using BookStore.Entities;
using BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.API.Controllers
{
    public class BookController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        // GET api/<controller>/5
        public Book Get(int id)
        {
            return _unitOfWork.BookRepository.Find(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Book value)
        {
            _unitOfWork.BookRepository.Create(value);
            _unitOfWork.SaveChanges();
        }

        // PUT api/<controller>/5
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}