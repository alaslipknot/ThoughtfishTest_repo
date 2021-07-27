//ui left and right clicks events

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Ui_Clickable : MonoBehaviour, IPointerClickHandler {

    public UnityEvent leftClickEvent;
    public UnityEvent rightClickEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            leftClickEvent.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClickEvent.Invoke();
        }
    }
}
