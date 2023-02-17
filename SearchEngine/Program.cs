using SearchEngine.Models;

List<string> files = new() {"doc1","doc2","doc3", "doc4"};
Searcher searcher = new(files);

Console.WriteLine("What word would you like to search for?");

string? input = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(input))
{
    string[] result = searcher.Search(input);
    Console.WriteLine($"The query '{input}' was found in these documents: ");
    foreach (string doc in result)
    {
        Console.WriteLine(doc);
    }
}