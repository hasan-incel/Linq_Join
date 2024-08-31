namespace LinqJoin
{
    class Program
    {
        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
        }

        public static void Main()
        {
            // Yazarlar listesi
            List<Author> authors = new List<Author>
        {
            new Author { AuthorId = 1, Name = "Orhan Pamuk" },
            new Author { AuthorId = 2, Name = "Elif Shafak" },
            new Author { AuthorId = 3, Name = "Yusuf Atılgan" }
        };

            // Kitaplar listesi
            List<Book> books = new List<Book>
        {
            new Book { BookId = 1, Title = "Kar", AuthorId = 1 },
            new Book { BookId = 2, Title = "Beyaz Kale", AuthorId = 1 },
            new Book { BookId = 3, Title = "Aşk", AuthorId = 2 },
            new Book { BookId = 4, Title = "Hikaye", AuthorId = 3 }
        };

            // LINQ sorgusu: Kitapları ve yazarları birleştir
            var query = from book in books
                        join author in authors on book.AuthorId equals author.AuthorId
                        select new
                        {
                            BookTitle = book.Title,
                            AuthorName = author.Name
                        };

            // Sonuçları ekrana yazdır
            foreach (var result in query)
            {
                Console.WriteLine($"Kitap: {result.BookTitle}, Yazar: {result.AuthorName}");
            }
        }
    }

}