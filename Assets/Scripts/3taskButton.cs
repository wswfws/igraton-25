using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Threading;
using Random = UnityEngine.Random;

public class ClickClickGame : MonoBehaviour
{
    public Button targetButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public int maxTimer;
    private int score;
    private bool isEnd;
    private float timer;
    

    void Start()
    {
        targetButton.onClick.AddListener(OnButtonClick);
        StartCoroutine(MoveButtonRoutine());
        scoreText.text = "Clicks: " + score + "/10";
    }

    void Update()
    {
        if (!isEnd)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer) EndGame(false);
            timerText.text = "Times remaining: " + Mathf.Ceil(maxTimer - timer) + " sec.";
        }
    }

    private void OnButtonClick()
    {
        if (isEnd) return;
        score++;
        scoreText.text = "Clicks: " + score + "/10";
        if (score >= 10)
        {
            EndGame(true);
        }

        var screenWidth = Screen.width;
        var screenHeight = Screen.height;
        var newPosition = new Vector3(Random.Range(100f, screenWidth - 100f), Random.Range(50f, screenHeight - 50f), 0);
        targetButton.transform.position = newPosition;
    }

    private IEnumerator MoveButtonRoutine()
    {
        while (score < 10)
        {
            Vector3 shakeOffset = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            targetButton.transform.position += shakeOffset;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void EndGame(bool isWin)
    {
        isEnd = true;
        timerText.text = isWin ? "Congrats! You win!" : "Times up! You loose!";
        Thread.Sleep(1000);
        gameObject.AddComponent<loadMain>().CallLoadMain();
    }
}
