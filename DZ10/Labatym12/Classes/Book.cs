namespace Library
{
    class Book
    {

        private string bookTitle;
        private string bookAuthor;
        private string publishingHouse;



        public string BookTitle
        {
            get
            {
                return bookTitle;
            }
        }
        public string BookAuthor
        {
            get
            {
                return bookAuthor;
            }
        }
        public string PublishingHouse
        {
            get
            {
                return publishingHouse;
            }
        }



        public override string ToString()
        {
            return $"{bookTitle}, {bookAuthor}, {publishingHouse}";
        }



        public Book(string bookTitle, string bookAuthor, string publishingHouse)
        {
            this.bookTitle = bookTitle;
            this.bookAuthor = bookAuthor;
            this.publishingHouse = publishingHouse;
        }
    }
}