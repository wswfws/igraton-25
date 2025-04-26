using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public Energy Energy { get; } = new();
    
    [SerializeField]
    public Slider energySlider;

    private Timer _secondTimer;

    private void Start()
    {
        _secondTimer = new(_ => Energy.OnSecond(), null, 0, 1000);
    }

    private void Update()
    {
        energySlider.value = Energy.Value;
    }
}