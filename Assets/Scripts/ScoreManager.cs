using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int BestScore { get; private set; }
    public int BestCombo { get; private set; }
    public bool HasReturnedFromGame { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetScore(int bestScore, int bestCombo)
    {
        Debug.Log("셋스코어 함수 호출");
        BestScore = bestScore;
        BestCombo = bestCombo;
    }

    public void MarkReturnFromGame()
    {
        HasReturnedFromGame = true;
    }

    public void ResetReturnFlag()
    {
        HasReturnedFromGame = false;
    }
}
