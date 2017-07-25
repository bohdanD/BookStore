using BookStore.Entities;
using BookStore.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.API.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IEnumerable<Author> Get()
        {
            return _unitOfWork.AuthorRepository.GetAll();
        }

        // DELETE api/<controller>
        public IHttpActionResult Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}