public class LinqQueries
{
    private List<Book> CollectionBooks = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.CollectionBooks = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json,
             new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> AllColletion()
    {
        return CollectionBooks;
    }
    public IEnumerable<Book> BooksAfter2000()
    {
        //return CollectionBooks.Where(p=> p.PublishedDate.Year>2000); //extension method
        return from l in CollectionBooks  where l.PublishedDate.Year >2000 select l; //query expresion
    }
    public IEnumerable<Book> moreOf250PagesAndTitleInAction()
    {
        //return CollectionBooks.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action")); //extension method
        return from l in CollectionBooks  where l.PageCount >250  && l.Title.Contains("in Action") select l; //query expresion
    }
}