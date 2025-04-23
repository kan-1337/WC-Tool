using WCTool.Services;

namespace UnitTest;
public class UnitTest1
{
    [Fact]
    public void GetWordCount_ReturnsCorrectCount()
    {
        var analyzer = new FileAnalyzer();
        var input = "This is a test string";
        var result = analyzer.GetWordCount(input);
        Assert.Equal(5, result);
    }
}
