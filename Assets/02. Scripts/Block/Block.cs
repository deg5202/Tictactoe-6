using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite oSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private SpriteRenderer markerSprite;
    public enum MarkerType { None, O, X }
    private int _blockIndex;

    //블록 초기화
    public void InitMarker(int blockIndex)
    {
        _blockIndex = blockIndex;
        SetMarker(MarkerType.None);
    }

    //마커 설정
    public void SetMarker(MarkerType markerType)
    {
        switch(markerType)
        {
            case MarkerType.O:
            markerSprite.sprite = oSprite;
            break;
            case MarkerType.X:
            markerSprite.sprite = xSprite;
            break;
            case MarkerType.None:
            markerSprite.sprite = null;
            break;
        }
    }

    private void OnMouseUpAsButton()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Debug.Log("블록 눌림"  + _blockIndex);
    }
}