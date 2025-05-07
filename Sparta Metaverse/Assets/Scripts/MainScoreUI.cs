using TMPro;
using UnityEngine;

public class MainScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestComboText;

    public int bestScore;
    public int bestCombo;
  
    private const string BestScoreKey = "BestScore";
    private const string BestComboKey = "BestCombo";

    void Start()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);
        SetScore(bestScore, bestCombo);
    }

    public void SetScore(int bestScore, int bestCombo)
    {
        bestScoreText.text = bestScore.ToString();
        bestComboText.text = bestCombo.ToString();
    }
}
