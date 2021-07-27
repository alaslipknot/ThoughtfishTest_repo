using UnityEngine;

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
        Debug.Log("Recording saved");
    }

    private void FixedUpdate()
    {
        if (isRecording)
        {
            actionTime += Time.fixedDeltaTime;

        }
    }

}
