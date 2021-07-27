using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(RectTransform))]
public class Ui_DragController : MonoBehaviour {

    RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Dragging(Vector2 delta, float canvasScale)
    {
        rect.anchoredPosition += delta / canvasScale;
    }
}
