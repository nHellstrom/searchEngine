namespace SearchEngine.Models;

public class Searcher {
    Dictionary<string, List<string>> searchIndex = new();

    public Searcher(params string[] documents) 
    {
        foreach (string document in documents) 
        {
            this.searchIndex = Index(document, searchIndex);
        }
    }

    public string ReadDocument(string documentName)
    {
        string basePath = System.AppContext.BaseDirectory;
        char separator = Path.DirectorySeparatorChar;
        return System.IO.File.ReadAllText($"{basePath}{separator}Data{separator}{documentName}.txt");
    }

    public string[] Tokenize(string inputString) 
    {
        string[] trimmedStrangeChars = inputString.Select(x => char.IsLetter(x) ? x.ToString().ToLower() : " ").ToArray();
        string noStrangeChars = string.Join("", trimmedStrangeChars);
        string[] splitted = noStrangeChars.Split(" ");

        List<string> holder = new();

        foreach (string x in splitted)
        {
            if (!string.IsNullOrWhiteSpace(x))
            {
                holder.Add(x);
            } 
        }

        return holder.ToArray();
    }

    public Dictionary<string,List<string>> Index(string documentName, Dictionary<string,List<string>> index)
    {
        string documentText = ReadDocument(documentName);
        string[] tokenizedDocument = Tokenize(documentText);

        foreach (string word in tokenizedDocument) {
            if (!index.ContainsKey(word))
            {
                index.Add(word, new List<string>{documentName});
            }
            else
            {
                index[word].Add(documentName);
            }
        }

        return index;
    }

    public string[] Search(string searchTerm)
    {
        if (searchIndex.TryGetValue(searchTerm, out List<string>? result))
        {
            return result.ToArray();
        }
        return Array.Empty<string>();
    }

}