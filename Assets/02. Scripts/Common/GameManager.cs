using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;
public class GameManager : Singleton<GameManager>
{

    [SerializeField] private GameObject settingsPanelPrefab;
    private Canvas canvas;
    //게임의 종류(싱글, 듀얼)
    private GameType _gameType;
    private GameLogic _gameLogic;

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //새로운 씬에서 Canvas 참조 가져오기
        canvas = FindFirstObjectByType<Canvas>();
        
        if(scene.name == SCENE_GAME)
        {
            var blockController = FindFirstObjectByType<BlockController>();
            if(blockController != null)
                blockController.InitBlocks();

            _gameLogic = new GameLogic(GameType.DualPlay, blockController);
        }
    }

    public void OpenSettingsPanel()
    {
        var settingsPanelObject = Instantiate(settingsPanelPrefab, canvas.transform);
        settingsPanelObject.GetComponent<SettingsPanelController>().Show();
    }

    public void ChangeToGameScene(GameType gameType)
    {
        _gameType = gameType;
        SceneManager.LoadScene("02. Game");
    }

    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("01. Main");
    }
}