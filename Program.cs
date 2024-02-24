using System.Linq;

LinqQueries queries = new LinqQueries();
PrintValues(queries.AllColletion());
void PrintValues(IEnumerable<Book> BookList)
{
    Console.WriteLine("{0,-60} {1,9} {2, 11}\n", "Titulo", "N. Paginas", "Fecha Publicación" );
    foreach(var item in BookList)
    {
        Console.WriteLine("{0,-60} {1,9} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}