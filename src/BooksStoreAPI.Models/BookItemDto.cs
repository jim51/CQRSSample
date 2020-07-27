namespace BooksStoreAPI.Models
{
    public class BookItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }

}
