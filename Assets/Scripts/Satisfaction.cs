using System;

public class Satisfaction
{
    private const int MaxSatisfaction = 100;
    
    private int _value = MaxSatisfaction;
    
    public int Value
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
