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
        SceneManager.LoadScene("mainScrean", LoadSceneMode.Additive);
    }

    public void LoadThirdGame()
    {
        UnloadNowScreen();
        SceneManager.LoadScene("3d mini-game", LoadSceneMode.Additive);
    }
    
    public void LoadFirstGame()
    {
        UnloadNowScreen();
        SceneManager.LoadScene("CollectWordGame", LoadSceneMode.Additive);
    }
}