using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour {

    #region Singleton
    public static FileManager _instance;
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

    public void NewFile()
    {
        Debug.Log("New File");
        UiGenerator._instance.NewGenerator();
    }

    public void SaveFile()
    {
        Debug.Log("Save File");
        UiGenerator._instance.SaveCurrentLayout();
    }

    public void LoadFile()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightControl)|| Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                NewFile();
            }else if (Input.GetKeyDown(KeyCode.S))
            {
                SaveFile();
            }
        }
    }

}
