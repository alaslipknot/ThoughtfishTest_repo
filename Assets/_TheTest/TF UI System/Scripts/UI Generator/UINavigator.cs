//This Class is responsible for the keyboard navigation

using UnityEngine;

public class UINavigator : MonoBehaviour {
    public UI_Main[] uiElements;
    public ActionRecorder[] actionRecorder;
    int uiID = 0;
    public void RefreshList()
    {
        uiElements = new UI_Main[UiGenerator._instance.totalPrefs];
        actionRecorder = new ActionRecorder[uiElements.Length];
        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i] = UiGenerator._instance.uiElements[i].GetComponent<UI_Main>();
            actionRecorder[i] = uiElements[i].GetComponent<ActionRecorder>();
        }
    }

    void NavigateWithTab()
    {
        if (uiID >= uiElements.Length)
        {
            uiElements[uiElements.Length - 1].HighlightEnd();
            actionRecorder[uiElements.Length - 1].RecordHighlightEnd();
            uiID = 0;
        }
        if (uiID > 0)
        {
            uiElements[uiID - 1].HighlightEnd();
            actionRecorder[uiID - 1].RecordHighlightEnd();
        }
        uiElements[uiID].HightlightBeging();
        actionRecorder[uiID].RecordHighlightBegin();
        uiID++;
    }

    void NavigateWithKeys(int dir)
    {

        if (dir == 1)
        {
            if (uiID < uiElements.Length - 1)
            {
                uiID++;
                uiElements[uiID].HightlightBeging();
                actionRecorder[uiID].RecordHighlightBegin();

                uiElements[uiID - 1].HighlightEnd();
                actionRecorder[uiID - 1].RecordHighlightEnd();
            }
        }
        else
        {
            if (uiID > 0)
            {
                uiID--;
                uiElements[uiID].HightlightBeging();
                actionRecorder[uiID].RecordHighlightBegin();

                uiElements[uiID + 1].HighlightEnd();
                actionRecorder[uiID + 1].RecordHighlightEnd();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            NavigateWithTab();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            NavigateWithKeys(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NavigateWithKeys(1);
        }
    }
}
