using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectWord : MonoBehaviour
{
    public string Word;
    public int CurrentIndexWord = 0;
    public GameObject LetterButton;
    public float colorChangeDuration = 0.5f;
    private HashSet<Button> buttonsClicked = new HashSet<Button>();

    void Start()
    {
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
        var buttonImage = button.GetComponent<Image>();
        var originalColor = buttonImage.color;
        var targetColor = isCorrect ? Color.green : Color.red;
        var elapsed = 0f;
        if (isCorrect && buttonsClicked.Add(button))
        {
            CurrentIndexWord++;
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
            buttonImage.color = originalColor;
            button.interactable = true;
        }
    }
}
