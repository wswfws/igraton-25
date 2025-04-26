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
            if (timer >= maxTimer)
            {
                EndGame(false);
                return;
            }
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
            return;
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
        if (isWin)
        {
            timerText.text = "Congrats! You win!";
        }
        else
        {
            timerText.text = "Times up! You loose!";
            UsersSatisfactionController.Satisfaction.Value -= 30;
        }
        StartCoroutine(EndMiniGame(3));
    }

    IEnumerator EndMiniGame(int time)
    {
        yield return new WaitForSeconds(time);
        gameObject.AddComponent<loadMain>().CallLoadMain();
    }
}
