using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class ActionRecorder : MonoBehaviour {
    public List<Action> recordedActions;
    RectTransform rect;
    UI_Main uiMain;
    bool CanPlay;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        uiMain = GetComponent<UI_Main>();
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

    public IEnumerator PlayActions()
    {
        int f = 0;

        f++;
        print(f);
        yield return recordedActions[f].timeOfAction;
        rect.anchoredPosition = recordedActions[f].position;
        switch (recordedActions[f].uiEvent)
        {
            case UiEvent.ClickLeft:
                uiMain.LeftClick();
                break;
            case UiEvent.ClickRight:
                uiMain.RightClick();
                break;
            case UiEvent.HighlightBegin:
                uiMain.HightlightBeging();
                break;
            case UiEvent.HighlightEnd:
                uiMain.HighlightEnd();
                break;
            case UiEvent.DragBegin:
                uiMain.DragBegin();
                break;
            case UiEvent.DragEnd:
                uiMain.DragEnd();
                break;
            case UiEvent.DragMoving:
                uiMain.Dragging();
                break;
        }

        if (f < recordedActions.Count - 1)
        {
            StartCoroutine(PlayActions());
        }
    }

    public void StartSequenceReplay()
    {
        CanPlay = true;
        i = 0;
        chrono = 0;
    }

    void PlayAction(int i)
    {
        rect.anchoredPosition = recordedActions[i].position;
        switch (recordedActions[i].uiEvent)
        {
            case UiEvent.ClickLeft:
                uiMain.LeftClick();
                break;
            case UiEvent.ClickRight:
                uiMain.RightClick();
                break;
            case UiEvent.HighlightBegin:
                uiMain.HightlightBeging();
                break;
            case UiEvent.HighlightEnd:
                uiMain.HighlightEnd();
                break;
            case UiEvent.DragBegin:
                uiMain.DragBegin();
                break;
            case UiEvent.DragEnd:
                uiMain.DragEnd();
                break;
            case UiEvent.DragMoving:
                uiMain.Dragging();
                break;
        }
    }

    int i = 0;
    float chrono = 0;
    private void Update()
    {
        if (!CanPlay) return;

        if (i < recordedActions.Count-1)
        {
            chrono += Time.deltaTime;
            if (chrono >= recordedActions[i].timeOfAction)
            {
                PlayAction(i);
                i++;
            }
        }
        
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

    #region Save and Load

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


[Serializable]
public class ActionSequence {
    public int uiId;
    public Action[] actions;
}

[Serializable]
public class Macro {
    public ActionSequence[] actionSequences;
}

#endregion
