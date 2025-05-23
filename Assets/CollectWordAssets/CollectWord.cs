using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectWord : MonoBehaviour
{
    public string Word;
    private int CurrentIndexWord = 0;
    public GameObject LetterButton;
    public TextMeshProUGUI mistakesText;
    public float colorChangeDuration = 0.5f;
    private HashSet<Button> buttonsClicked = new HashSet<Button>();
    private int correctSymbols = 0;
    private bool isEnd = false;
    private int mistakesDoneCount;

    void Start()
    {
        mistakesText.text = "Mistakes done: 0/3";
        var lettersPos = GameObject.FindGameObjectsWithTag("LetterPos");
        var usedPositions = new HashSet<int>();
        foreach (var letter in Word)
        {
            while (true)
            {
                var position = Random.Range(0, lettersPos.Length);
                if (!usedPositions.Add(position)) continue;
                var newButton = Instantiate(LetterButton, lettersPos[position].transform);
                var buttonText = newButton.GetComponentInChildren<TMP_Text>();
                buttonText.text = letter.ToString();
                var buttonComponent = newButton.GetComponent<Button>();
                buttonComponent.onClick.AddListener(() => OnLetterClick(buttonComponent));
                break;
            }
        }
    }
    
    void Update()
    {
        
    }

    void OnLetterClick(Button button)
    {
        var buttonText = button.GetComponentInChildren<TMP_Text>();
        var isCorrect = buttonText.text == Word[CurrentIndexWord].ToString();
        StartCoroutine(HandleButtonClick(button, isCorrect));
    }
    
    IEnumerator HandleButtonClick(Button button, bool isCorrect)
    {
        if (isEnd) yield break;
        var buttonImage = button.GetComponent<Image>();
        var originalColor = buttonImage.color;
        ColorUtility.TryParseHtmlString("#70B02C", out var correctColor);
        ColorUtility.TryParseHtmlString("#BA2727", out var wrongColor);
        var targetColor = isCorrect ? correctColor : wrongColor;
        var elapsed = 0f;
        if (isCorrect && buttonsClicked.Add(button))
        {
            CurrentIndexWord++;
            correctSymbols++;
            if (correctSymbols == Word.Length) gameObject.AddComponent<loadMain>().CallLoadMain();
            Debug.Log(correctSymbols);
        }
        while (elapsed < colorChangeDuration)
        {
            buttonImage.color = Color.Lerp(originalColor, targetColor, elapsed / colorChangeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        buttonImage.color = targetColor;
        if (isCorrect) Destroy(button.gameObject);
        else
        {
            mistakesDoneCount++;
            mistakesText.text = "Mistakes done: " + mistakesDoneCount + "/3";
            if (mistakesDoneCount == 3)
            {
                isEnd = true;
                Debug.Log(13223132);
                yield return new WaitForSeconds(1);
                mistakesText.text = "You loose(";
                yield return new WaitForSeconds(3);
                UsersSatisfactionController.Satisfaction.Value -= 30;
                gameObject.AddComponent<loadMain>().CallLoadMain();
            }
            buttonImage.color = originalColor;
            button.interactable = true;
        }
    }
}
