public class Energy
{
    public const float MaxEnergy = 100;
    
    private float _value = MaxEnergy;
    
    public float Value => _value;

    public void OnSecond()
    {
        _value -= MaxEnergy / 20;
    }

    public void OnLever()
    {
        _value += MaxEnergy / 2.5f;
        if (_value > MaxEnergy) _value = MaxEnergy;
    }
}
