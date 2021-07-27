
using UnityEngine;
using UnityEngine.UI;
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
