using BookStore.Entities;
using BookStore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.Concrete
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly StoreContext _context;

        public AuthorRepository(StoreContext context)
        {
            _context = context;
        }

        public void Create(Author item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            _context.Authors.Add(item);
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Books.RemoveRange(author.Books);
                _context.Authors.Remove(author);
            }
        }

        public Author Find(int id)
        {
            return _context.Authors.Find(id);
        }

        public ICollection<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public void Update(Author item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
