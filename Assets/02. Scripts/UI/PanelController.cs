using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;

    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();   
    }
    //팝업 표시
    public void Show()
    {
        Debug.Log("Show panel   ");
        
        _canvasGroup.alpha = 0;
        panelTransform.localScale = Vector3.zero;

        _canvasGroup.DOFade(1, 1f).SetEase(Ease.Linear);
        panelTransform.DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    //팝업 숨기기
    public void Hide()
    {
        Debug.Log("Hide panel   ");

        _canvasGroup.DOFade(0, 1f).SetEase(Ease.Linear);
        panelTransform.DOScale(0, 1f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });        
    }
}
