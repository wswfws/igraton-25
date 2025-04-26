using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TextGenerator : MonoBehaviour
{
    public TextMeshProUGUI text;
    private static Dictionary<string, string> incorrectWords = new()
    {
        ["наживasfdasыми"] = "ножевыми",
        ["железывадорожный"] = "железнодорожной"
    };

    private static HashSet<string> goodWords = new();

    void Start()
    {
        text.text = "Тело женщины с наживasfdasыми ранениями нашли на железывадорожный станции в Екатеринбурге";
        foreach (var word in goodWords)
        {
            text.text = text.text.Replace(word, incorrectWords[word]);
        }
    }

    void Update()
    {
        
    }

    public void CheckIsCorrect(string word)
    {
        if (!incorrectWords.ContainsKey(word)) return;
        goodWords.Add(word);
        switch (new System.Random().Next(3))
        {
            case 0:
                gameObject.AddComponent<Load3Game>().CallLoad3Game();
                break;
            case 1:
                gameObject.AddComponent<Load1Game>().CallLoad1Game();
                break;
            case 2:
                gameObject.AddComponent<Load2Game>().CallLoad2Game();
                break;
        }
        EnergyController.DestroyTimer();
    }
}