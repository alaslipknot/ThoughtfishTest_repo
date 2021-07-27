//Listen to Pointer and fire highlight begins/end events
//as well as determine when to show the help text when hovering

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ui_Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public UnityEvent highlightStartEvent;
    public UnityEvent highlightEndEvent;
    public UnityEvent showHelpEvent;
    float threshhold = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightStartEvent.Invoke();
        StartCoroutine("ShowHelp");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlightEndEvent.Invoke();
        StopCoroutine("ShowHelp");
    }

    IEnumerator ShowHelp()
    {
        yield return new WaitForSeconds(threshhold);
        showHelpEvent.Invoke();
    }
}
