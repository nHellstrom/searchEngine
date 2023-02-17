namespace SearchEngine.Models;

public class Searcher {
    Dictionary<string, List<string>> searchIndex = new();
    string basePath = System.AppContext.BaseDirectory;
    char separator = Path.DirectorySeparatorChar;

    public Searcher(params string[] documents) 
    {
        foreach (string document in documents) 
        {
            this.searchIndex = Index(document, searchIndex);
        }
    }

    public Searcher(List<string> documents) 
    {
        foreach (string document in documents) 
        {
            this.searchIndex = Index(document, searchIndex);
        }
    }

    public Searcher() 
    {
        string[] documents = Directory.GetFiles($"{basePath}{separator}Data", "*.txt");
        
        foreach (string document in documents) 
        {
            string documentName = Path.GetFileNameWithoutExtension(document);
            this.searchIndex = Index(documentName, searchIndex);
        }
    }

    public string ReadDocument(string documentName)
    {
        string path = $"{basePath}{separator}Data{separator}{documentName}.txt";
        return System.IO.File.ReadAllText(path);
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

    public List<string> SortResult(List<string> toSort)
    {
        string[] distinctHits = toSort.Distinct().ToArray();

        List<(string term, int weight)> holder = new();

        foreach (string hit in distinctHits)
        {
            int weight = toSort.Count(x => x.Equals(hit));
            holder.Add((hit,weight));
        }
        holder.Sort(
            delegate((string term, int weight) a, (string term, int weight) b)
            {
                if (a.weight > b.weight)
                {
                    return -1;
                }
                if (b.weight > a.weight)
                {
                    return 1;
                }
                return 0;
            });
        
        List<string> output = new();
        foreach (var result in holder)
        {
            output.Add(result.term);
        }

        return output;
    }

    public string[] Search(string searchTerm)
    {
        if (searchIndex.TryGetValue(searchTerm.ToLower(), out List<string>? result))
        {
            return SortResult(result).ToArray();
            
        }


        return Array.Empty<string>();
    }

}