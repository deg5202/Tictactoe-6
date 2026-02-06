using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject settingsPanelPrefab;
    private Canvas canvas;
    //게임의 종류(싱글, 듀얼)
    private GameType _gameType;

    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        canvas = FindFirstObjectByType<Canvas>();        
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