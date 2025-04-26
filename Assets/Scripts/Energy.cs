public class Energy
{
    public const int MaxEnergy = 100;
    
    private int _value = MaxEnergy;
    
    public int Value { get; private set; }

    public void OnSecond()
    {
        _value -= 10;
    }

    public void OnLever()
    {
        _value += 40;
    }
}
