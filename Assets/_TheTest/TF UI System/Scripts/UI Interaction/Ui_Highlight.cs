using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ui_Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public UnityEvent highlightStartEvent;
    public UnityEvent highlightEndEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightStartEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlightEndEvent.Invoke();
    }
}
