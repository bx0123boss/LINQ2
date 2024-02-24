using System.Linq;

LinqQueries queries = new LinqQueries();
//toda la collecion
//PrintValues(queries.AllColletion());
//libros despues del 2000
//PrintValues(queries.BooksAfter2000());
//libros con 250 paginas o más 
PrintValues(queries.moreOf250PagesAndTitleInAction());
void PrintValues(IEnumerable<Book> BookList)
{
    Console.WriteLine("{0,-60} {1,9} {2, 11}\n", "Titulo", "N. Paginas", "Fecha Publicación" );
    //PRINT
    foreach(var item in BookList)
    {
        Console.WriteLine("{0,-60} {1,9} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}