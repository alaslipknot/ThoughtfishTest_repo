using UnityEngine;
using System.IO;
using UnityEngine.UI;
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

    public string layoutPath, recordPath;
    public int chosenFileId;
    public string[] layoutFiles;
    public Text fileSelectText;
    private void Start()
    {
        InitDirectories();
    }
    public void InitDirectories()
    {
        layoutPath = Application.persistentDataPath + "/Layouts/";
        recordPath = Application.persistentDataPath + "/Records/";
        if (!Directory.Exists(layoutPath))
        {
            Directory.CreateDirectory(layoutPath);
        }

        if (!Directory.Exists(recordPath))
        {
            Directory.CreateDirectory(recordPath);
        }
    }

    public void NewFile()
    {
        Debug.Log("New File");
        UiGenerator._instance.NewGenerator();
    }

    public void SaveFile()
    {
        Debug.Log("Save File");
        UiGenerator._instance.SaveCurrentLayout(layoutPath + "Layout_" + GetLayoutFileCount() + ".json");
    }

    public void LoadFile()
    {
        //string fullPath = layoutPath + "Layout_" + chosenFileId + ".json";
        UiGenerator._instance.LoadLayout(layoutFiles[chosenFileId]);
    }


    public int GetLayoutFileCount()
    {
        DirectoryInfo dir = new DirectoryInfo(layoutPath);
        return dir.GetFiles().Length;
    }

    public void RefreshFileList()
    {
        layoutFiles = Directory.GetFiles(layoutPath);
        SetFileSelectText();

    }

    public void ChangeFile(int i)
    {
        chosenFileId += i;
        if (chosenFileId < 0)
        {
            chosenFileId = 0;
        }
        else if (chosenFileId > GetLayoutFileCount() - 1)
        {
            chosenFileId = GetLayoutFileCount() - 1;
        }
        SetFileSelectText();
    }

    void SetFileSelectText()
    {
        fileSelectText.text = (chosenFileId + 1) + "/" + (layoutFiles.Length);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                NewFile();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SaveFile();
            }
        }
    }

}
