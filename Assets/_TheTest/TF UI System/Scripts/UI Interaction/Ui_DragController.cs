//where the dragging movement happens
//it's separated from the other class just in case
//some extra effects or whatever are needed
//then this can be extended without modifying the base one

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
