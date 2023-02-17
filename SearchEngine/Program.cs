using SearchEngine.Models;

// Console.WriteLine("Welcome!");
// Console.WriteLine("Welcome! You will be given two choices for where and what files you'd like to search.");
// Console.WriteLine("Option 1) Search all text files in the 'Data' folder of this program.");
// Console.WriteLine("Option 2) Input the path to a text file, where each row is the absolute path to text documents to be searched. Please use Windows syntax (i.e. use '\' as separator character)");
// Console.WriteLine("Please write either 1 or 2 and press enter.");

// switch (Console.Read())
// {
//     case 1:
//         Searcher searcher = new();
//         break;
//     case 2:
//         Console.WriteLine("Please paste the path to your text document.");
//         string? pathInput = Console.ReadLine();
//         Searcher searcher = new(pathInput);
// }

List<string> files = new() {"doc1","doc2","doc3", "doc4"};
// Searcher searcher = new(files);
Searcher searcher = new();
// Searcher searcher = new(@"C:\Users\nikhe\OneDrive\Skrivbord\listoffiles.txt");

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