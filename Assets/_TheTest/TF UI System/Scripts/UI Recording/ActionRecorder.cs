using UnityEngine;
using System;
using System.Collections.Generic;


public class ActionRecorder : MonoBehaviour {
    public List<Action> recordedActions;
    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }


    public void Record(Action action)
    {
        action.DebugAction(recordedActions.Count);
        recordedActions.Add(action);
    }
    bool CanRecord()
    {
        return RecordManager._instance.isRecording;
    }
    Action CreateAction(float t, UiEvent e, Vector3 p)
    {
        return new Action { timeOfAction = t, uiEvent = e, position = p };
    }

    #region Different Actions

    public void RecordLeftClick()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.ClickLeft,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    public void RecordRightClick()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.ClickRight,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    public void RecordHighlightBegin()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.HighlightBegin,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }
    public void RecordHighlightEnd()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.HighlightEnd,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    public void RecordDragBegin()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.DragBegin,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    public void RecordDragEnd()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.DragEnd,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    public void RecordDragMoving()
    {
        if (!CanRecord()) return;

        Action action = CreateAction(RecordManager._instance.actionTime,
                                      UiEvent.DragMoving,
                                      rect.anchoredPosition
                                    );
        Record(action);
    }

    #endregion


}

#region Data classes
[Serializable]
public class Action {
    public float timeOfAction;
    public UiEvent uiEvent;
    public Vector3 position;

    public void DebugAction(int id)
    {
        Debug.Log("------" + id + "------");
        Debug.Log("Time: " + timeOfAction);
        Debug.Log("UiEvent: " + uiEvent);
        Debug.Log("Position: " + position);
    }
}

public enum UiEvent {
    HighlightBegin, HighlightEnd,
    ClickLeft, ClickRight,
    DragBegin, DragEnd, DragMoving
}

#endregion
