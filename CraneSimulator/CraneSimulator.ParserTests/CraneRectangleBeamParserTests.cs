using CraneSimulator.CraneComponent;
using CraneSimulator.Parser;

namespace CraneSimulator.ParserTests;

public class CraneRectangleBeamParserTests
{
    private readonly string _projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../"));
    
    /// <summary>
    /// check if the <see cref="RectangleBeamComponent"/> gets deserialized + if all properties are set
    /// all properties are set in json -> so IsThisAValidComponent should return true
    /// </summary>
    [Fact]
    public void TestValidJsonFile()
    {
        CraneRectangleBeamParser parser = new();
        var jsonPath = Path.GetFullPath(Path.Combine(_projectRoot, "RectangleBeamTestFiles", "ValidRectangleBeam.json"));
        
        RectangleBeamComponent? component = parser.DeserializeRectangleBeamJson(jsonPath);
        
        Assert.NotNull(component);
        Assert.True(component.IsThisAValidComponent());
    }
    
    /// <summary>
    /// check if the <see cref="RectangleBeamComponent"/> gets deserialized
    /// not all properties are set in json -> so IsThisAValidComponent should return false
    /// </summary>
    [Fact]
    public void TestInvalidJsonFile()
    {
        CraneRectangleBeamParser parser = new();
        var jsonPath = Path.GetFullPath(Path.Combine(_projectRoot, "RectangleBeamTestFiles", "InvalidRectangleBeam.json"));
        
        RectangleBeamComponent? component = parser.DeserializeRectangleBeamJson(jsonPath);
        
        Assert.NotNull(component);
        Assert.False(component.IsThisAValidComponent());
    }
}