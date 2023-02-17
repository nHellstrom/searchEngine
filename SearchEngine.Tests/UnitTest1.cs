using SearchEngine.Models;
using Xunit;

namespace SearchEngine.Tests;

public class UnitTest1
{
    Searcher searcher = new();

    [Fact]
    public void TokenizationShouldWork()
    {
        //Arrange
        string testString = "General Kenobi. You are a bold one.";

        //Act
        var results = searcher.Tokenizer(testString);

        //Assert
        string[] expected = new string[] {"General", "Kenobi", "You", "are", "a", "bold", "one"};
        Assert.Equal(expected, results);
    }
}