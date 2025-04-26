using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public Energy Energy { get; } = new();
    
    [SerializeField]
    public Slider EnergySlider;

    private Timer _secondTimer;

    private void Start()
    {
        _secondTimer = new(_ => Energy.OnSecond(), null, Timeout.InfiniteTimeSpan, TimeSpan.FromSeconds(1));
    }

    private void Update()
    {
        EnergySlider.value = Energy.Value;
    }
}