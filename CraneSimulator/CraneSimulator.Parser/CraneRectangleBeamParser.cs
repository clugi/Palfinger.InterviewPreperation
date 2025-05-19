using System.Text.Json;
using CraneSimulator.CraneComponent;

namespace CraneSimulator.Parser;

/// <summary>
/// parser for the rectangle beam
/// </summary>
public class CraneRectangleBeamParser
{
    /// <summary>
    /// deserialize a json file to a <see cref="RectangleBeamComponent"/>
    /// </summary>
    /// <param name="iBeamJsonPath"></param>
    /// <returns>deserialized <see cref="RectangleBeamComponent"/></returns>
    public RectangleBeamComponent? DeserializeRectangleBeamJson(string iBeamJsonPath)
    {
        if (!File.Exists(iBeamJsonPath))
        {
            Serilog.Log.Error("File does not exist: " + iBeamJsonPath);
            return null;
        }
        
        try
        {
            string jsonContent = File.ReadAllText(iBeamJsonPath);
            RectangleBeamComponent? component = JsonSerializer.Deserialize<RectangleBeamComponent?>(jsonContent);
            
            return component;
        }
        catch (Exception e)
        {
            Serilog.Log.Error("Invalid json for deserialization: " + iBeamJsonPath);
            Serilog.Log.Error("Exception message: " + e);
            
            return null;
        }
    }
}