
public abstract class BaseState
{
    public abstract void OnEnter(GameLogic gameLogic);                //상태 진입시 호출
    public abstract void HandleMove(GameLogic gameLogic, int index);  //플레이어 이동 처리(클릭시)
    public abstract void OnExit(GameLogic gameLogic);                 //상태 종료 시 호출
    public abstract void HandleNextTurn(GameLogic gameLogic);         //다음 턴 처리

    public void ProcessMove(GameLogic gamelogic,int index,Constants.PlayerType playerType)
    {
        //특정위치에 마커가 표시가 되어 있다면.
        if(gamelogic.PlaceMarker(index, playerType))
        {            
            HandleNextTurn(gamelogic);
        }        
    }
}