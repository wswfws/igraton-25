using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    
    [SerializeField] private EnergyController energyController;

    private bool isOn = false;
    
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnClick()
    {
        isOn = !isOn;
        image.sprite = isOn ? on : off;
        energyController.Energy.OnLever();
    }
}
