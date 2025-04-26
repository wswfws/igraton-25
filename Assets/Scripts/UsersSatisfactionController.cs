using UnityEngine;

public class UsersSatisfactionController : MonoBehaviour
{
    public int SatisfactionDecrease { get; set; } = 5;
    
    public Satisfaction Satisfaction { get; private set; } = new();

    private void Update()
    {
        Satisfaction.Value -= SatisfactionDecrease;
    }
}
