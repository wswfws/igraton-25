using UnityEngine;

public class Load1Game: MonoBehaviour
{
    public void CallLoad1Game()
    {
        // Находим объект "loader" в сцене
        GameObject loaderObject = GameObject.Find("loader");
        
        if (loaderObject != null)
        {
            // Получаем компонент SceneLoader
            SceneLoader sceneLoader = loaderObject.GetComponent<SceneLoader>();
            Debug.Log(sceneLoader);
            
            if (sceneLoader != null)
            {
                // Вызываем метод LoadMain()
                sceneLoader.LoadFirstGame();
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