using System.Text.Json.Serialization;

namespace CraneSimulator.CraneComponent.SubClassesRectangleBeam;

/// <summary>
/// geometrical properties of the cross-section -> essential to calculate I , W
/// </summary>
public class Geometry
{
    /// <summary>
    /// height of the rectangle in mm
    /// </summary>
    [JsonPropertyName("HeightMm")]
    public int? HeightMm { get; set; }
    
    /// <summary>
    /// width of the rectangle in mm
    /// </summary>
    [JsonPropertyName("WidthMm")]
    public int? WidthMm { get; set; }
    
    /// <summary>
    /// check if all properties are set
    /// </summary>
    /// <returns>true if all properties are set, false otherwise</returns>
    public bool IsThisAValidComponent()
    {
        return HeightMm.HasValue && WidthMm.HasValue;
    }
}