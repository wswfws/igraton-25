using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextWordFinder : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textMeshPro;

    public void OnPointerClick(PointerEventData eventData)
    {
        var linkIndex = TMP_TextUtilities.FindIntersectingWord(textMeshPro, eventData.position, eventData.pressEventCamera);

        if (linkIndex == -1)
        {
            Debug.Log("No word found");
            return;
        }
        
        var linkInfo = textMeshPro.textInfo.wordInfo[linkIndex];
        var clickedWord = linkInfo.GetWord();
        Debug.Log("Clicked word: " + clickedWord);
    }
}