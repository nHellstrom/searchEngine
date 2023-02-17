namespace SearchEngine.Models;

public class WeightedResult {
    public string documentName;
    public double termFrequency;

    public WeightedResult(string document, double weight)
    {
        documentName = document;
        termFrequency = weight;
    }
}