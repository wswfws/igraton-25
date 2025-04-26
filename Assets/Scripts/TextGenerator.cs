using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class News
{
    public string text;
    public Dictionary<string, string> incorrectWords;

    public News(string text, Dictionary<string, string> incorrectWords)
    {
        this.text = text;
        this.incorrectWords = incorrectWords;
    }
}

public static class NewsLibrary
{
    public static readonly List<News> news = new()
    {
        new News(
            "Тело женщины с наживasfdasыми ранениями нашли на железывадорожный станции в Екатеринбурге",
            new Dictionary<string, string>
            {
                ["наживasfdasыми"] = "ножевыми",
                ["железывадорожный"] = "железнодорожной"
            }),
        new News(
            "Коза влезла НаНаНаНа электропровода, штабы добраться до зелёных веточек",
            new Dictionary<string, string>
            {
                ["НаНаНаНа"] = "на",
                ["штабы"] = "чтобы"
            }),
        new News(
            "Женщина попала в Буклет рекордов Гиннесса, собрав самую очень большую коллекцию миньонов",
            new Dictionary<string, string>
            {
                ["Буклет"] = "книгу",
                ["очень"] = ""
            })
    };

    public static News GetRandomNews()
    {
        var random = new Random();
        var rndInd = random.Next(news.Count);
        return news[rndInd];
    }
}

public class TextGenerator : MonoBehaviour
{
    public TextMeshProUGUI text;
    private static Dictionary<string, string> incorrectWords;

    private static HashSet<string> goodWords = new();

    void Start()
    {
        var news = NewsLibrary.GetRandomNews();
        incorrectWords = news.incorrectWords;
        text.text = news.text;
        foreach (var word in goodWords)
        {
            text.text = text.text.Replace(word, incorrectWords[word]);
        }
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