//This class is responsible for Generating random ui elements 
//From a given prefab list
//Saving the ui layout to a json file
//load a ui layout from a json file

using UnityEngine;
using System.IO;

public class UiGenerator : MonoBehaviour {


    #region Singleton
    public static UiGenerator _instance;
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

    public GameObject[] uiPrefabs;
    public RectTransform[] uiElements;
    public UiGenData uiGenData;
    public RectTransform parent;
    public int totalPrefs = 6;
    public Vector2 hSpacing;
    public Vector2 vSpacing;
    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        uiElements = new RectTransform[totalPrefs];
        uiGenData = new UiGenData();
        uiGenData.Init(totalPrefs);
        for (int i = 0; i < totalPrefs; i++)
        {
            int prefId = Random.Range(0, uiPrefabs.Length);
            uiElements[i] = Instantiate(uiPrefabs[prefId], parent).GetComponent<RectTransform>();

            Vector2 pos = Vector2.zero;
            pos.y = 500 + Random.Range(vSpacing.x, vSpacing.y); ;
            if (i > 0)
            {
                pos = uiElements[i - 1].anchoredPosition;
                pos.y = 500;
                pos.x += uiElements[i - 1].sizeDelta.x + Random.Range(hSpacing.x, hSpacing.y);
            }
            uiElements[i].anchoredPosition = pos;
            uiGenData.prefabsId[i] = prefId;
            uiGenData.pos[i] = pos;
        }

        GetComponent<UINavigator>().RefreshList();
    }

    public void NewGenerator()
    {
        ClearUi();
        Generate();
    }

    public void GenerateFromLoadedFile()
    {
        ClearUi();
        uiElements = new RectTransform[totalPrefs];
        for (int i = 0; i < totalPrefs; i++)
        {
            int prefId = uiGenData.prefabsId[i];
            uiElements[i] = Instantiate(uiPrefabs[prefId], parent).GetComponent<RectTransform>();
            uiElements[i].anchoredPosition = uiGenData.pos[i];
        }
        GetComponent<UINavigator>().RefreshList();
    }

    public void ClearUi()
    {
        foreach (RectTransform item in uiElements)
        {
            Destroy(item.gameObject);
        }
    }

    public void SaveCurrentLayout(string path)
    {
        string layout = JsonUtility.ToJson(uiGenData);
        File.WriteAllText(path, layout);
        Debug.Log("Saved data to " + path);
    }
    public void LoadLayout(string fullPath)
    {
        print(fullPath);
        string json = File.ReadAllText(fullPath);
        uiGenData = JsonUtility.FromJson<UiGenData>(json);
        GenerateFromLoadedFile();
    }



}

[System.Serializable]
public class UiGenData {
    public int[] prefabsId;
    public Vector3[] pos;

    public void Init(int size)
    {
        prefabsId = new int[size];
        pos = new Vector3[size];
    }
    public void EnterData(int i, int prefId, Vector3 p)
    {
        prefabsId[i] = prefId;
        pos[i] = p;
    }
}