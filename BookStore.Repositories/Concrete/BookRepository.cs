using BookStore.Entities;
using BookStore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories.Concrete
{
    public class BookRepository : IRepository<Book>
    {
        private readonly StoreContext _context;

        public BookRepository(StoreContext context)
        {
            _context = context;
        }

        public void Create(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            var author = _context.Authors.Find(item.Author.Id);
            item.Author = author;
            _context.Books.Add(item);
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public Book Find(int id)
        {
            return _context.Books.Find(id);
        }

        public ICollection<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Update(Book item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
