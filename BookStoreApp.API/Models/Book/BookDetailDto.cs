namespace BookStoreApp.API.Models.Book
{
    public class BookDetailDto : BaseDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public string Image { get; set; }
        public string summary { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
