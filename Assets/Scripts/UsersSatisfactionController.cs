using UnityEngine;
using UnityEngine.UI;

public class UsersSatisfactionController : MonoBehaviour
{
    public Slider SatisfactionSlider;
    
    public static Satisfaction Satisfaction { get; } = new();
    
    private void Update()
    {
        SatisfactionSlider.value = Satisfaction.Value;
    }
}
