using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TextGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    private Dictionary<string, string> incorrectWords = new()
    {
        ["наживasfdasыми"] = "ножевыми",
        ["железывадорожный"] = "железнодорожный"
    };

    void Start()
    {
        text.text = "Тело женщины с наживasfdasыми ранениями нашли на железывадорожный станции в Екатеринбурге";
    }

    void Update()
    {
        
    }

    public void CheckIsCorrect(string word)
    {
        // Corrected: Use ContainsKey instead of Contains
        if (incorrectWords.ContainsKey(word))
        {
            text.text = text.text.Replace(word, incorrectWords[word]);
            gameObject.AddComponent<Load3Game>().CallLoad3Game();
        }
    }
}