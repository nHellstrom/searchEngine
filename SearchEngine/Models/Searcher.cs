namespace SearchEngine.Models;

public class Searcher {
    Dictionary<string, List<WeightedResult>> searchIndex = new();

    public Searcher() 
    {
        string basePath = System.AppContext.BaseDirectory;
        
        string[] files = Directory.GetFiles($"{basePath}Data", "*.txt");

        foreach (string document in files) 
        {
            this.searchIndex = Index(document, searchIndex);
        }
    }

    public Searcher(string path) 
    {
        string[] files = GetAllDocuments(path);

        foreach (string document in files) 
        {
            this.searchIndex = Index(document, searchIndex);
        }
    }

    private string[] GetAllDocuments(string path)
    {
        string[] files = System.IO.File.ReadLines(path).ToArray();
        List<string> paths = new();

        foreach (string filePath in files)
        {
            paths.Add(filePath);
        }

        return paths.ToArray();
    }

    private string[] Tokenize(string inputString) 
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

    private Dictionary<string,List<WeightedResult>> Index(string documentName, Dictionary<string,List<WeightedResult>> index)
    {
        string documentText = System.IO.File.ReadAllText(documentName);
        string[] tokenizedDocument = Tokenize(documentText);

        foreach (string word in tokenizedDocument) {
            if (!index.ContainsKey(word))
            {
                double tf = CalculateTermFrequency(tokenizedDocument, word);
                index.Add(word, new List<WeightedResult>{new WeightedResult(documentName, tf)});
            }
            else
            {
                double tf = CalculateTermFrequency(tokenizedDocument,word);
                index[word].Add(new WeightedResult(documentName, tf));
            }
        }

        return index;
    }

    private double CalculateTermFrequency(string[] document, string query)
    {
        double wordCount = document.Length;
        double termCount = document.Count(x => x.ToLower().Equals(query.ToLower()));
        return Math.Log(termCount/wordCount);
    }

    private string[] SortResult(List<WeightedResult> toSort)
    {
        toSort.Sort(
            delegate(WeightedResult a, WeightedResult b)
            {
                if (a.termFrequency > b.termFrequency)
                {
                    return -1;
                }
                else if (b.termFrequency > a.termFrequency)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        );
        string[] output = toSort.DistinctBy(x => x.documentName).Select(x => x.documentName).ToArray();

        return output;
    }

    public string[] Search(string searchTerm)
    {
        if (searchIndex.TryGetValue(searchTerm.ToLower(), out List<WeightedResult>? result))
        {
            return SortResult(result);
        }


        return Array.Empty<string>();
    }

}