using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public static Energy Energy { get; } = new();

    [SerializeField] public Slider energySlider;

    public static Timer _secondTimer;

    private void Start()
    {
        _secondTimer = new(1000);
        _secondTimer.Elapsed += (_, _) => Energy.OnSecond();
        _secondTimer.AutoReset = true;
        _secondTimer.Enabled = true;
    }

    private void Update()
    {
        energySlider.value = Energy.Value;
    }

    public static void DestroyTimer()
    {
        _secondTimer.Stop();
        _secondTimer.Dispose();
    }
}