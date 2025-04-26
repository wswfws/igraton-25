using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string currentScrean = "";

    public void Start()
    {
        SceneManager.LoadScene("startScrean", LoadSceneMode.Additive);
        currentScrean = "startScrean";
    }

    private void UnloadNowScreen()
    {
        if (SceneManager.GetSceneByName(currentScrean).IsValid())
        {
            SceneManager.UnloadSceneAsync(currentScrean);
        }
    }

    public void LoadMain()
    {
        UnloadNowScreen();
        currentScrean = "mainScrean";
        SceneManager.LoadScene("mainScrean", LoadSceneMode.Additive);
    }

    public void LoadThirdGame()
    {
        UnloadNowScreen();
        currentScrean = "3d mini-game";
        SceneManager.LoadScene("3d mini-game", LoadSceneMode.Additive);
    }

    public void LoadFirstGame()
    {
        UnloadNowScreen();
        currentScrean = "CollectWordGame";
        SceneManager.LoadScene("CollectWordGame", LoadSceneMode.Additive);
    }

    public void LoadBadEnding()
    {
        UnloadNowScreen();
        currentScrean = "BadEnding";
        SceneManager.LoadScene("BadEnding", LoadSceneMode.Additive);
    }

    public void LoadSecondGame()
    {
        UnloadNowScreen();
        currentScrean = "2nd mini game";
        SceneManager.LoadScene("2nd mini game", LoadSceneMode.Additive);
    }
}