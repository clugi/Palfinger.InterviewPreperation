namespace CraneSimulator.StressSimulator;

public class ShearForce
{
    public double TotalLoadN { get; set; }     // Total point load in Newton
    public double BeamLengthM { get; set; }    // Beam length in meters
    public double LoadPositionM { get; set; }  // Distance from left support

    /// <summary>
    /// Left support reaction (upwards)
    /// </summary>
    public double GetLeftReactionN() =>
        TotalLoadN * (BeamLengthM - LoadPositionM) / BeamLengthM;

    /// <summary>
    /// Right support reaction (upwards)
    /// </summary>
    public double GetRightReactionN() =>
        TotalLoadN * LoadPositionM / BeamLengthM;

    /// <summary>
    /// Shear force just to the left of the load
    /// </summary>
    public double GetShearLeftOfLoad() => GetLeftReactionN();

    /// <summary>
    /// Shear force just to the right of the load
    /// </summary>
    public double GetShearRightOfLoad() => GetLeftReactionN() - TotalLoadN;
}