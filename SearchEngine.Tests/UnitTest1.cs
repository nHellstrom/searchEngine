using SearchEngine.Models;
using Xunit;

namespace SearchEngine.Tests;

public class UnitTest1
{
    Searcher searcher = new("doc1", "doc2", "doc3");

    [Fact]
    public void TokenizationShouldWork()
    {
        //Arrange
        string testString = "General Kenobi. You are a bold one.";

        //Act
        var results = searcher.Tokenize(testString);

        //Assert
        string[] expected = new string[] {"general", "kenobi", "you", "are", "a", "bold", "one"};
        Assert.Equal(expected, results);
    }

    [Fact]
    public void IndexerShouldReturnDictioanry()
    {
        // Arrange
        string doc1 = "Hello there";
        string doc2 = "A Jedi uses the Force for knowledge and defense, never for attack";
        string doc3 = "Are you threatening me, master Jedi?";
        Dictionary<string, List<string>> testDictionary = new();

        // Act
        testDictionary = searcher.Index(doc1, testDictionary);
        testDictionary = searcher.Index(doc2, testDictionary);
        testDictionary = searcher.Index(doc3, testDictionary);

        // Assert
        List<string>? result = testDictionary.GetValueOrDefault("jedi");
        List<string> expected = new List<string> {doc2, doc3};

        Assert.Equal(expected, result);
    }

    [Fact]
    public void SearchReturnsDocs()
    {
        string[] result = searcher.Search("fox");
        string[] expected = {"doc1", "doc3"};
        Assert.Equal(expected,result);
    }
}