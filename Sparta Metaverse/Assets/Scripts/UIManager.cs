using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum UIState
{
    Home,
    Game,
    Score,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("���� UI")]
    public GameObject explanationPanel;

    [Header("���� �� ���ھ� UI (�����ÿ��� null ����)")]
    public MainScoreUI mainScoreUI;

    UIState currentState = UIState.Home;

    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;
    TheStack theStack = null;

    private void Awake()
    {
        Instance = this;

        // ScoreManager ������ ����
        if (ScoreManager.Instance == null)
        {
            new GameObject("ScoreManager").AddComponent<ScoreManager>();
        }

        theStack = FindObjectOfType<TheStack>();
        homeUI = GetComponentInChildren<HomeUI>(true);
        gameUI = GetComponentInChildren<GameUI>(true);
        scoreUI = GetComponentInChildren<ScoreUI>(true);

        homeUI?.Init(this);
        gameUI?.Init(this);
        scoreUI?.Init(this);

        if (explanationPanel != null)
        {
            explanationPanel.SetActive(true);
            homeUI?.gameObject.SetActive(false);
            gameUI?.gameObject.SetActive(false);
            scoreUI?.gameObject.SetActive(false);
        }
    }

    public void CloseExplanation()
    {
        explanationPanel?.SetActive(false);
        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(state);
        gameUI?.SetActive(state);
        scoreUI?.SetActive(state);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
        // �� �̵� ���� "���� �÷���" ����
        ScoreManager.Instance?.MarkReturnFromGame();

#if UNITY_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene("MainScene");
#else
        SceneManager.LoadScene("MainScene");
#endif
    }

    public void UpdateScore()
    {
        gameUI?.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI?.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ScoreManager.Instance?.SetScore(theStack.BestScore, theStack.BestCombo);
        ChangeState(UIState.Score);
    }
}
