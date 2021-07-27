using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Ui_Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {


    public UnityEvent beginDragEvent;
    public UnityEvent endDragEvent;
    public UnityEvent DraggingEvent;

    public Ui_DragController dragController;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginDragEvent.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragController.Dragging(eventData.delta, 
                                MainCanvas._instance.canvas.scaleFactor);
        DraggingEvent.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endDragEvent.Invoke();
    }


}


