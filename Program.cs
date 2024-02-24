// See https://aka.ms/new-console-template for more information
using System.Linq;
var frutas = new String[]{ "sandia", "fresa", "Mango", "Mango de azucar", "Mango Tomy"};
var MangoList = frutas.Where(p=> p.StartsWith("Mango")).ToList();
MangoList.ForEach(p => Console.WriteLine(p));

