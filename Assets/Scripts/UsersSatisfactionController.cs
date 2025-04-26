using UnityEngine;
using UnityEngine.UI;

public class UsersSatisfactionController : MonoBehaviour
{
    public Slider SatisfactionSlider;
    
    public Satisfaction Satisfaction { get; private set; } = new();
    
    private void Update()
    {
        SatisfactionSlider.value = Satisfaction.Value;
    }
}
