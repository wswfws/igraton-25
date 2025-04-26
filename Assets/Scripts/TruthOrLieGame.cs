using System.Collections;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TruthOrLieGame : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Button trueButton;
    [SerializeField] private Button falseButton;
    [SerializeField] private float timePerQuestion = 2f;
    
    private string[] questions = {
        "Земля плоская",
        "Вода кипит при 100°C",
        "Кошки могут летать",
        "Python - это язык программирования"
    };

    private bool[] answers = { false, true, false, true };
    private int currentQuestion = 0;
    private float timer;
    private bool gameOver = false;

    void Start()
    {
        trueButton.onClick.AddListener(() => CheckAnswer(true));
        falseButton.onClick.AddListener(() => CheckAnswer(false));
        ShowQuestion();
    }

    void Update()
    {
        if (!gameOver)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && !gameOver)
            {
                UsersSatisfactionController.Satisfaction.Value -= 30;
                StartCoroutine(EndGame("Время вышло!"));
            }
        }
    }

    void ShowQuestion()
    {
        if (gameOver || currentQuestion >= questions.Length) return;
        
        questionText.text = questions[currentQuestion];
        timer = timePerQuestion;
    }

    void CheckAnswer(bool playerAnswer)
    {
        if (gameOver) return;
        
        bool isCorrect = (playerAnswer == answers[currentQuestion]);
        
        if (!isCorrect)
        {
            questionText.text = "Неправильно! Игра окончена.";
            UsersSatisfactionController.Satisfaction.Value -= 30;
            Update();
            StartCoroutine(EndGame("Неправильно! Игра окончена."));
            
            return;
        }

        currentQuestion++;
        
        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            questionText.text = "Победа! Все ответы верные!";
            Update();
            StartCoroutine(EndGame("Победа! Все ответы верные!"));
            
        }
    }

    IEnumerator EndGame(string message)
    {
        gameOver = true;
        trueButton.interactable = false;
        falseButton.interactable = false;
        yield return new WaitForSeconds(3);
        gameObject.AddComponent<loadMain>().CallLoadMain();
    }
}