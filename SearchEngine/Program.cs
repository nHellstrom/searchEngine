using SearchEngine.Models;

Console.WriteLine("");
Console.WriteLine("Please parse the path to a text document listing the files you want to be searched through.");
Console.WriteLine(@"Specify one file path per line in the file. Both Windows(*\*.txt) and Unix (*/*.txt) path syntaxes should be acceptable");
Console.WriteLine(@"(only Windows syntax has been tested)");
Console.WriteLine(@"If you'd like to use a pre-made set of documents, simply leave the input empty.");


// string? inputPath = Console.ReadLine();

Searcher searcher = new();

// if (!string.IsNullOrWhiteSpace(inputPath))
// {
//     try {
//         searcher = new Searcher(inputPath!.Trim().Replace("\"",""));
//     }
//     catch(FileNotFoundException)
//     {
//         Console.WriteLine("Seems like you entered a bad file path!");
//         Console.WriteLine("Reverted to the default data files.");
//         searcher = new Searcher();
//     }
// }

Console.WriteLine("What word would you like to search for?");

// string? input = Console.ReadLine() ?? "";
string input = "fox";

string[] result = searcher.Search(input);
Console.WriteLine($"The query '{input}' was found in these documents: ");
Console.WriteLine($"[{string.Join("\n", result)}]");

Console.WriteLine();
Console.WriteLine("Press any key to exit");
Console.ReadLine();