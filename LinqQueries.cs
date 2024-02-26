using System.Reflection;
using System.Transactions;

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
    public bool AllBooksHasStatus()
    {
        return CollectionBooks.All(p => p.Status!= string.Empty);
    }

    public bool SomeOfBookWasPublishedIn2005()
    {
        return CollectionBooks.Any(p=>p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> BooksOfPython()
    {
        return CollectionBooks.Where(p=> p.Categories.Contains("Python"));
    }
     public IEnumerable<Book> BooksOfJavaByAscending()
    {
        return CollectionBooks.Where(p=> p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> BooksHas450PagesDescending()
    {
        return CollectionBooks.Where(p=> p.PageCount >450).OrderByDescending(P => P.PageCount);
    }
     public IEnumerable<Book> ThreeFirstBooksOfJavaByDescending()
    { 
        return CollectionBooks
        .Where(p=> p.Categories.Contains("Java"))
        .OrderBy(p => p.PublishedDate)
        .TakeLast(3);
    }
    public IEnumerable<Book> ThirdAndFourthBookMore400Pages()
    {
        return CollectionBooks
        .Where(p=> p.PageCount > 400)
        .Take(4)
        .Skip(2);
        
    }
    public IEnumerable<Book> ThreeFirstBooks()
    {
       return CollectionBooks.Take(3)
        .Select(p=> new Book() {
           Title= p.Title, PageCount = p.PageCount
        });
    }
    public int CantityOfBooksBetween200and500Pages()
    {
        return CollectionBooks.Count(p=> p.PageCount >= 200 && p.PageCount <=500);
    }
    public DateTime DatePublishedMin()
    {
        return CollectionBooks.Min(p => p.PublishedDate);
    }
    public int MaxNumOfPages()
    {
        return CollectionBooks.Max(p=>p.PageCount);
    }
    public Book BookMinPages()
    {
        return CollectionBooks.Where(p=> p.PageCount >0).MinBy(p=> p.PageCount);
    }
    public Book BookMDateMax()
    {
        return CollectionBooks.MaxBy(p=> p.PublishedDate);
    }
    public int SumOfOPagesBw0and500() 
    {
        return CollectionBooks.Where(p=> p.PageCount >=0 && p.PageCount <=500).Sum(p => p.PageCount);
    }
    public string BooksNameAfter2015()
    {
        return CollectionBooks
        .Where(p=>p.PublishedDate.Year >2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if(TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros +=  next.Title;
            return TitulosLibros;
        });
    }
}