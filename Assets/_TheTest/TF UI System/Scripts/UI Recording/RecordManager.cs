using UnityEngine;
using System.IO;
public class RecordManager : MonoBehaviour {


    #region Singleton
    public static RecordManager _instance;
    private void OnEnable()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    public float actionTime;
    public bool isRecording;
    public bool isPlaying;
    public float playSpeed = 10;
    public void StartRecording()
    {
        Debug.Log("Recording started");
        isRecording = true;
        actionTime = 0;
    }

    public void StopRecording()
    {
        Debug.Log("Recording stopped");
        isRecording = false;
        SaveRecording();
    }

    public void SaveRecording()
    {
        int uiCount = UiGenerator._instance.parent.childCount;
        Macro macro = new Macro();
        macro.actionSequences = new ActionSequence[uiCount];
        for (int i = 0; i < uiCount; i++)
        {
            ActionRecorder recorder = UiGenerator._instance.parent.GetChild(i).GetComponent<ActionRecorder>();
            ActionSequence sequence = new ActionSequence();
            sequence.uiId = i;
            sequence.actions = recorder.recordedActions.ToArray();
            macro.actionSequences[i] = sequence;
        }

        string records = JsonUtility.ToJson(macro);
        string path = FileManager._instance.recordPath + "Rec.json";
        File.WriteAllText(path, records);
        Debug.Log("Saved data to " + path);
    }


    public void LoadAndPlayRecording()
    {
        isPlaying = true;
        string path = FileManager._instance.recordPath + "Rec.json";
        string json = File.ReadAllText(path);
        Macro macro = JsonUtility.FromJson<Macro>(json);
        print(macro.actionSequences.Length);

        for (int i = 0; i < macro.actionSequences.Length; i++)
        {
            ActionRecorder recorder = UiGenerator._instance.parent.GetChild(i).GetComponent<ActionRecorder>();
            ActionSequence sequence = new ActionSequence();
            sequence.uiId = macro.actionSequences[i].uiId;
            sequence.actions = macro.actionSequences[i].actions;
            recorder.recordedActions.Clear();
            for (int j = 0; j < sequence.actions.Length; j++)
            {
                recorder.recordedActions.Add(sequence.actions[j]);
                
            }
            //recorder.StartCoroutine(recorder.PlayActions());
            recorder.StartSequenceReplay();
        }
    }


    private void FixedUpdate()
    {
        if (isRecording)
        {
            actionTime += Time.fixedDeltaTime;

        }
    }

}
