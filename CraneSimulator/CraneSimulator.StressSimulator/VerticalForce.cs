namespace CraneSimulator.StressSimulator;

public class VerticalForce
{
    /// <summary>
    /// mass in kg
    /// </summary>
    public double MassKg { get; set; }    
    
    /// <summary>
    /// earth gravity -> m/s²
    /// </summary>
    public double Gravity { get; set; } = 9.81; 

   /// <summary>
   /// get vertical force on something
   /// </summary>
   /// <returns></returns>
    public double GetForce()
    {
        return MassKg * Gravity;
    }
   
    /// <summary>
    /// get vertical force in kilonewton on something
    /// </summary>
    /// <returns></returns>
    public double GetForceKn()
    {
        return GetForce() / 1000.0;
    }
}