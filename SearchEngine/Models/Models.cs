using System.Linq;

namespace SearchEngine.Models;

public class Searcher {
    public string[] Tokenizer(string inputString) {

        string[] trimmedStrangeChars = inputString.Select(x => char.IsLetter(x) ? x.ToString() : " ").ToArray();
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
}