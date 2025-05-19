using System.Reflection;
using System.Text.Json.Serialization;
using CraneSimulator.CraneComponent.SubClassesIBeam;

namespace CraneSimulator.CraneComponent;

/// <summary>
/// rectangle-beam element
/// </summary>
public class RectangleBeamComponent
{
    #region Private Properties

    private Geometry? _geometry;

    #endregion

    #region Public Properties

    /// <summary>
    /// name of the component
    /// </summary>
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    /// <summary>
    /// yield strength of the component -> compare against bending stress 𝜎
    /// σ > MaterialYieldStrengthMPa -> component may fail
    /// </summary>
    [JsonPropertyName("MaterialYieldStrengthMPa")]
    public int? MaterialYieldStrengthMPa { get; set; }

    /// <summary>
    /// geometrical properties of the cross-section -> essential to calculate I , W
    /// calculates the crossection when valid values are set
    /// </summary>
    [JsonPropertyName("Geometry")]
    public Geometry? Geometry
    
    {
        get => _geometry;
        set 
        {
            _geometry = value;

            if (_geometry.HeightMm is not null
                && _geometry.HeightMm > 0
                && _geometry.WidthMm is not null
                && _geometry.WidthMm > 0)
            {
                CalculateCrossSectionKeyFigures((int)_geometry.HeightMm, (int)_geometry.WidthMm);
            }
        }
    }
    
    public int CrossSection { get; set; }
    
    /// <summary>
    /// moment of inertia (I) in mm⁴ – measures bending stiffness
    /// </summary>
    public double MomentOfInertia { get; set; }

    /// <summary>
    /// section modulus (W) in mm³ – used for stress calculation (σ = M / W)
    /// </summary>
    public double SectionModulus { get; set; }
    

    #endregion

    #region Public Methods

    /// <summary>
    /// check if all properties are set
    /// </summary>
    /// <returns>true if all properties are set, false otherwise</returns>
    public bool IsThisAValidComponent()
    {
        foreach (PropertyInfo prop in this.GetType().GetProperties())
        {
            var value = prop.GetValue(this);
            if (value == null)
            {
                return false;
            }

            // if property is a class -> iterate through this class and check for null properties
            if (!prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(string))
            {
                var isValidMethod = prop.PropertyType.GetMethod("IsThisAValidComponent");
                if (isValidMethod != null)
                {
                    var result = (bool?)isValidMethod.Invoke(value, null);
                    if (result == false)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    #endregion

    #region Private Methods

    private void CalculateCrossSectionKeyFigures(int geometryHeightMm, int geometryWidthMm)
    {
        CrossSection = (int)(_geometry.HeightMm * _geometry.WidthMm);
        // I = (b * h^3) / 12
        MomentOfInertia = (geometryWidthMm * Math.Pow(geometryHeightMm, 3)) / 12.0;

        // W = I / (h/2)
        SectionModulus = MomentOfInertia / (geometryHeightMm / 2.0);
    }

    #endregion
}