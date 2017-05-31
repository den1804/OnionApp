using OnionApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnionApp.Domain.Core;

namespace OnionApp.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private OrderContext _db;
        private bool _disposed = false;
        public BookRepository()
        {
            _db = new OrderContext();
        }
        public IEnumerable<Book> GetBookList()
        {
            return _db.Books.ToList();
        }
        public Book GetBook(int id)
        {
            return _db.Books.Find(id);
        }
        public void Create(Book book)
        {
            _db.Books.Add(book);
        }
        public void Update(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Book book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
