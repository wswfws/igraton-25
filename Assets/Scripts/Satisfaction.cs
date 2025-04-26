using System;

public class Satisfaction
{
    private const float MaxSatisfaction = 100;
    
    private float _value = MaxSatisfaction;
    
    public float Value
    {
        get => _value;
        set
        {
            if (value is < 0 or > MaxSatisfaction)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and MaxSatisfaction");
            }
            
            _value = value;
        }
    }
}
