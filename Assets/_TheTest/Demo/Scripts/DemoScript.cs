using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class DemoScript : MonoBehaviour {
    public GameObject toggleWhenRightClick;
    public GameObject toggleHighlight;
    public Image img;
    public RectTransform rect;

    public void RightClickToggle()
    {
        toggleWhenRightClick.SetActive(!toggleWhenRightClick.activeSelf);
    }

    public void LeftClick()
    {

        DOTween.Kill(img);
        Color imgColor = img.color;
        imgColor.a = 1;
        img.color = imgColor;
        img.DOFade(0, 0.2f).SetLoops(2, LoopType.Yoyo);

    }

    public void HighlightBegin()
    {

        toggleHighlight.SetActive(true);
    }

    public void HighlightEnd()
    {
        toggleHighlight.SetActive(false);
    }
}

