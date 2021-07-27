//Main canvas reference
//needed to access the scale factor when dragging

using UnityEngine;
public class MainCanvas : MonoBehaviour {

    public Canvas canvas;
    #region Singleton
    public static MainCanvas _instance;
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
}
