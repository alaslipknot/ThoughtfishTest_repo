using UnityEngine;
using UnityEngine.Events;

public class UI_Main : MonoBehaviour {

    public UnityEvent OnLeftClick, OnRightClick, OnHighLightBegin, OnHighlightEnd,
                      OnDragBegin, OnDragEnd, OnDragging;
    public void LeftClick()
    {
        OnLeftClick.Invoke();
    }

    public void RightClick()
    {
        OnRightClick.Invoke();
    }

    public void HightlightBeging()
    {
        OnHighLightBegin.Invoke();
    }
    public void HighlightEnd()
    {
        OnHighlightEnd.Invoke();
    }

    public void DragBegin()
    {
        OnDragBegin.Invoke();
    }

    public void DragEnd()
    {
        OnDragEnd.Invoke();
    }

    public void Dragging()
    {
        OnDragging.Invoke();
    }

}
