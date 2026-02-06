using UnityEngine;

public class SettingsPanelController : PanelController
{

    //x 버튼을 누르면
    public void OnClickClose()
    {
        //1. 설정 저장
        //2. 창닫기
        Hide();
    }
}