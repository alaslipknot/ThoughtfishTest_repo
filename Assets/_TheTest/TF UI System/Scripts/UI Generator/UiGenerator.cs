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
    RectTransform[] uiElements;
    public UiGenData uiGenData;
    public RectTransform parent;
    public int totalPrefs = 6;
    public Vector2 hSpacing;
    public Vector2 vSpacing;
    private void Start()
    {
        Generate();
        print(Application.persistentDataPath);
    }

    public void Generate()
    {
        uiElements = new RectTransform[totalPrefs];
        uiGenData = new UiGenData();
        uiGenData.Init(IDFromDir(), totalPrefs);
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
            uiGenData.EnterData(i, prefId, pos);
        }
    }

    public void NewGenerator()
    {
        foreach (RectTransform item in uiElements)
        {
            Destroy(item.gameObject);
        }
        Generate();
    }

    public void SaveCurrentLayout()
    {
        string path = Application.persistentDataPath + "/";
        string layout = JsonUtility.ToJson(uiGenData);
        File.WriteAllText(path + uiGenData.id + ".json", layout);
        Debug.Log("Saved data to " + Application.persistentDataPath + uiGenData.id + ".json");
    }

    string IDFromDir()
    {
        string path = Application.persistentDataPath + "/";
        DirectoryInfo dir = new System.IO.DirectoryInfo(path);
        int count = dir.GetFiles().Length;
        return "Lay_" + count;
    }
}

[System.Serializable]
public class UiGenData {
    public string id;
    public int[] prefabsId;
    public Vector3[] positions;
    public void Init(string id, int size)
    {
        this.id = id;
        prefabsId = new int[size];
        positions = new Vector3[size];
    }
    public void EnterData(int i, int prefId, Vector3 p)
    {
        prefabsId[i] = prefId;
        positions[i] = p;
    }
}