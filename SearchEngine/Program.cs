using SearchEngine.Models;

Searcher searcher = new();
searcher.Tokenizer("Will this work????Gah!");

Console.WriteLine(searcher.Tokenizer("Probably not!"));

foreach (string x in searcher.Tokenizer("Will this work!!! We will see..."))
{
    Console.WriteLine(x);
}