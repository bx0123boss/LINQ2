using System.Linq;

LinqQueries queries = new LinqQueries();
//toda la collecion
//PrintValues(queries.AllColletion());
//libros despues del 2000
//PrintValues(queries.BooksAfter2000());
//libros con 250 paginas o más 
//PrintValues(queries.moreOf250PagesAndTitleInAction());

//todos los libros tienen status
Console.WriteLine($"Todos los libros tienen status? - {queries.AllBooksHasStatus()}");

//algún libro se imprimmió en 2005
Console.WriteLine($"Algún libro se imprimmió en 2005? - {queries.SomeOfBookWasPublishedIn2005()}");

PrintValues(queries.ThirdAndFourthBookMore400Pages());


//tres primeros libros filtrados con Select
PrintValues(queries.ThreeFirstBooks());
Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 paginas: {queries.CantityOfBooksBetween200and500Pages()}");

//libro con mayor numero de paginas
Console.WriteLine($"El libro con el mayor numero de paginas tiene: {queries.MaxNumOfPages()}");
//fecha de publicacion menor de todos los libros
Console.WriteLine($"Fecha de publicación menor: {queries.DatePublishedMin()}");
//libro con menor numero de paginas
var bookMin = queries.BookMDateMax();
Console.WriteLine($"{bookMin.Title} - {bookMin.PageCount}");

//suma de pagina de libros entre  0 y 500
Console.WriteLine($"La suma de paginas es: {queries.SumOfOPagesBw0and500()}");

//titulos de libros
Console.WriteLine($"Libros publicados después del 2015: {queries.BooksNameAfter2015()}");

//promedio de caracteres de titulos
Console.WriteLine($"promedio de caracteres de titulos: {queries.PromedioCharactersTitle()}");

//Libros publicados a partir del 2000 agrupados por año
PrintGroup(queries.BooksPublishedAfter2000());
void PrintValues(IEnumerable<Book> BookList)
{
    Console.WriteLine("{0,-60} {1,9} {2, 11}\n", "Titulo", "N. Paginas", "Fecha Publicación" );
    //PRINT
    foreach(var item in BookList)
    {
        Console.WriteLine("{0,-60} {1,9} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void PrintGroup(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}