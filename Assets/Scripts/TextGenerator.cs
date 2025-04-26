using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TextGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    private static Dictionary<string, string> incorrectWords = new()
    {
        ["наживasfdasыми"] = "ножевыми",
        ["железывадорожный"] = "железнодорожный"
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
        // Corrected: Use ContainsKey instead of Contains
        if (incorrectWords.ContainsKey(word))
        {
            goodWords.Add(word);
            gameObject.AddComponent<Load3Game>().CallLoad3Game();
            EnergyController.DestroyTimer();
        }
    }
}