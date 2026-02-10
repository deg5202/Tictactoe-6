using static Constants;

public class GameLogic
{
    public BlockController blockController;

    private PlayerType[,] _board;

    public BaseState playerAState;
    public BaseState playerBState;

    private BaseState _currentState;
    public GameLogic(GameType gametype, BlockController blockController) 
    {
        //BlockContrller 할당
        this.blockController = blockController;

        //보드 정보 초기화
        _board = new PlayerType[BOARD_SIZE, BOARD_SIZE];

        switch(gametype)
        {
            case GameType.SinglePlay:
                playerAState = new PlayerState(true);
                playerBState = new AIState();

                SetState(playerAState);
                break;

            case GameType.DualPlay:
                playerAState = new PlayerState(true);
                playerBState = new PlayerState(false);

                //초기 상태 설정 (플레이어 a부터 시작)
                SetState(playerAState);
                break;
        }
    }

    //턴 바뀔 때 호출되는 메서드(상태전환 메서드)
    public void SetState(BaseState newState)
    {
        _currentState?.OnExit(this);
        _currentState = newState;
        _currentState.OnEnter(this);        
    }

    //마커 표시
    public bool PlaceMarker(int index, PlayerType playerType)
    {
        var row = index / BOARD_SIZE;
        var col = index % BOARD_SIZE;
        //해당 위치에 이미 마커가 있는지 확인, 뭔가 있으면 false 반환
        if (_board[row,col] != Constants.PlayerType.None) return false;

        blockController.PlaceMarker(index, playerType);

        _board[row, col] = playerType;

        return true;
    }

    //턴변경
    public void ChangeGameState()
    {
        if (_currentState == playerAState)
            SetState(playerBState);
        else
            SetState(playerAState);
    }

    //게임 결과 확인
    public void CheckGameResult()
    {
        //승리 조건 확인 로직 구현
    }

    public bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {

        return false;
    }

}