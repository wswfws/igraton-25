using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lawer : MonoBehaviour
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    private bool isOn = false;
    
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnClock()
    {
        isOn = !isOn;
        if (isOn)
        {
            image.sprite = on;
        }
        else
        {
            image.sprite = off;
        }
    }
    void Update()
    {
        
    }
}
