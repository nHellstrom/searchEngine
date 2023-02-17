using SearchEngine.Models;

Searcher searcher = new("doc1","doc2","doc3");

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

// searcher.Tokenize("Will this work????Gah!");

// Console.WriteLine(searcher.Tokenize("Probably not!"));

// foreach (string x in searcher.Tokenize("Will this work!!! We will see..."))
// {
//     Console.WriteLine(x);
// }

        // Arrange
        // string doc1 = "Hello there";
        // string doc2 = "A Jedi uses the Force for knowledge and defense, never for attack";
        // string doc3 = "Are you threatening me, master Jedi?";
        // Dictionary<string, List<string>> testDictionary = new();

        // // Act
        // testDictionary = searcher.Index(doc1, testDictionary);
        // testDictionary = searcher.Index(doc2, testDictionary);
        // testDictionary = searcher.Index(doc3, testDictionary);

        // // Assert
        // List<string>? result = testDictionary.GetValueOrDefault("jedi");
        // List<string> comparison = new List<string> {doc2, doc3};

        // Console.WriteLine("Final result:");
        // Console.WriteLine(string.Join(",", result));
        // Console.WriteLine("That was it.");
        // Console.WriteLine(string.Join(",", comparison));


//////////////// TESTING FILE READING

        // string basePath = System.AppContext.BaseDirectory;
        // Console.WriteLine(basePath);
        // char separator = Path.DirectorySeparatorChar;
        // string documentText = System.IO.File.ReadAllText($"{basePath}{separator}Data{separator}doc1.txt");
        // Console.WriteLine(documentText);
