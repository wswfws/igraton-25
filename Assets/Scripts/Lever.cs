using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    
    private bool isTimeout = false;
    
    private volatile bool changeToOn = false;
    
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (changeToOn)
        {
            image.sprite = on;
            changeToOn = false;
        }
    }

    public void OnClick()
    {
        if (isTimeout)
        {
            return;
        }
        
        isTimeout = true;
        var timer = new Timer(3000);
        timer.AutoReset = false;
        image.sprite = off;
        EnergyController.Energy.OnLever();
        timer.Elapsed += (_, _) =>
        {
            isTimeout = false;
            changeToOn = true;
            timer.Stop();
        };
        timer.Start();
    }
}
