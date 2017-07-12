using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Entities;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Concrete
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context)
        {
            _context = context;
        }

        public void Create(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            var books = new List<Book>();
            foreach (var book in item.Books)
            {
                books.Add(_context.Books.Find(book.Id));
            }
            item.Books = books;
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }

        public Order Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public ICollection<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void Update(Order item)
        {
            var order = _context.Orders.Find(item.Id);
            if (order == null)
            {
                throw new ArgumentException();
            }
            var books = new List<Book>();
            foreach (var book in item.Books)
            {
                books.Add(_context.Books.Find(book.Id));
            }
            order.Books = books;
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
