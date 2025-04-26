using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBadEnd : MonoBehaviour
{
    public void CallLoadBadEnd()
    {
        // Находим объект "loader" в сцене
        GameObject loaderObject = GameObject.Find("loader");
        Debug.Log("PIZDEC");
        
        if (loaderObject != null)
        {
            // Получаем компонент SceneLoader
            SceneLoader sceneLoader = loaderObject.GetComponent<SceneLoader>();
            Debug.Log(sceneLoader);
            
            if (sceneLoader != null)
            {
                // Вызываем метод LoadMain()
                sceneLoader.LoadBadEnding();
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
