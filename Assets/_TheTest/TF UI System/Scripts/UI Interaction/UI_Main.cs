//This Class is responsible for all the calls 
//from all the other classes
//it also work as a bridge between the "base" UI interaction classes
//and any other Action class, in this case it's the DemoScript.cs

using UnityEngine;
using UnityEngine.Events;

public class UI_Main : MonoBehaviour {

    public UnityEvent OnLeftClick, OnRightClick, 
                      OnHighLightBegin, OnHighlightEnd, OnHighlightHelp,
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
    public void HighlightShowHelp()
    {
        OnHighlightHelp.Invoke();
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
