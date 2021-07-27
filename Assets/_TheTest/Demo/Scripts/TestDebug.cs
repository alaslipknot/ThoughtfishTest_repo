
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TestDebug : MonoBehaviour {

    public Image img;
    public RectTransform rect;


    public void LeftClick()
    {
        DOTween.KillAll();
        img.color = Color.white;
        img.DOFade(0, 0.2f).SetLoops(2, LoopType.Yoyo);
    }

    public void RightClick()
    {
        DOTween.KillAll();
        rect.DOScaleX(-1 * Mathf.Sign(rect.localScale.x), .2f);
    }

    public void HighlightStart()
    {
        DOTween.KillAll();
        rect.DOScale(1.2f * Mathf.Sign(rect.localScale.x), .2f);
    }

    public void HighlightEnd()
    {
        DOTween.KillAll();
        rect.DOScale(1.0f * Mathf.Sign(rect.localScale.x), .2f);
    }


    public void Drag()
    {
        
    }
}
