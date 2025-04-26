using UnityEngine;

public class Load3Game: MonoBehaviour
{
    public void CallLoad3Game()
    {
        // Находим объект "loader" в сцене
        GameObject loaderObject = GameObject.Find("loader");
        Debug.Log(3);
        
        if (loaderObject != null)
        {
            // Получаем компонент SceneLoader
            SceneLoader sceneLoader = loaderObject.GetComponent<SceneLoader>();
            Debug.Log(sceneLoader);
            
            if (sceneLoader != null)
            {
                // Вызываем метод LoadMain()
                sceneLoader.LoadThirdGame();
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