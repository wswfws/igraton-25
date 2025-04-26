using UnityEngine;

public class loadMain: MonoBehaviour
{
    public void CallLoadMain()
    {
        // Находим объект "loader" в сцене
        GameObject loaderObject = GameObject.Find("loader");
        
        if (loaderObject)
        {
            // Получаем компонент SceneLoader
            SceneLoader sceneLoader = loaderObject.GetComponent<SceneLoader>();
            
            if (sceneLoader)
            {
                // Вызываем метод LoadMain()
                sceneLoader.LoadMain();
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