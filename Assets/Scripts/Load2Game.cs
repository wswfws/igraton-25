using UnityEngine;

public class Load2Game: MonoBehaviour
{
    public void CallLoad2Game()
    {
        GameObject loaderObject = GameObject.Find("loader");
        
        if (loaderObject != null)
        {
            SceneLoader sceneLoader = loaderObject.GetComponent<SceneLoader>();
            Debug.Log(sceneLoader);
            
            if (sceneLoader != null)
            {
                sceneLoader.LoadSecondGame();
            }
            else
            {
                Debug.LogError("У объекта 'loader' нет компонента SceneLoader!");
            }
        }
        else
        {
            Debug.LogError("Объект 'loader' не найден в сцене!");
        }
    }
}