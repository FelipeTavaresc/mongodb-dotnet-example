using MongoDB.Driver;
using MongoExample.Models;

namespace MongoExample.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _books = database.GetCollection<Book>(config["MongoDB:CollectionName"]);
        }

        public List<Book> Get() => _books.Find(book => true).ToList();

        public Book Get(string id) => _books.Find(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn)
            => _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(string id)
            => _books.DeleteOne(book => book.Id == id);
    }
}
