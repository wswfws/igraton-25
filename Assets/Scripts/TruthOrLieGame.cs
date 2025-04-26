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
                EndGame("Время вышло!");
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
            EndGame("Неправильно! Игра окончена.");
            return;
        }

        currentQuestion++;
        
        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            EndGame("Победа! Все ответы верные!");
        }
    }

    void EndGame(string message)
    {
        gameOver = true;
        questionText.text = message;
        trueButton.interactable = false;
        falseButton.interactable = false;
    }
}