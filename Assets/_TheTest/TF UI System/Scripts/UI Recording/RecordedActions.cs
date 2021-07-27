using System.Collections.Generic;
using UnityEngine;
using System;
public class RecordedActions : MonoBehaviour {

    public class OnUiInteractArgs : EventArgs {
        public Action action;
    }


    public List<Action> recordedActions;
    public event EventHandler OnUiInteract;
   
    public void TriggerRecordingEvent()
    {
        OnUiInteract?.Invoke(this, EventArgs.Empty);
    }

    public void Record(Action action)
    {
        action.DebugAction(recordedActions.Count);
        recordedActions.Add(action);
    }
}




