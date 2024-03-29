using UnityEngine;
using UnityEngine.SceneManagement;

public enum Stages
{
    Intro,
    Game,
    Outro
}

public class GameManager : MonoBehaviour
{
    public Stages currentStage;
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        currentStage = Stages.Intro;
        UIManager.Instance.OpenStartScreen();

        Application.targetFrameRate = 120;
    }

    private void OnEnable()
    {
        PlayerManager.OnPlayerDeath += PlayerIsDead;
        PlayerManager.OnPlayerStarted += SetStageToGame;
    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerDeath -= PlayerIsDead;
        PlayerManager.OnPlayerStarted -= SetStageToGame;
    }

    private void PlayerIsDead()
    {
        SoundManager.Instance.ChangeBackgroundMusicToEndGame();
        currentStage = Stages.Outro;
        UIManager.Instance.OpenEndGameScreen();
    }

    private void SetStageToGame()
    {
        UIManager.Instance.OpenGameScreen();
        currentStage = Stages.Game;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
/*
    TODO Tek dusman varyantlarini degistir
    serit degistiren dusman
    arada ates eden dusman

*/