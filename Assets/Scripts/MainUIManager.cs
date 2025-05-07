using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [Header("메인 씬 스코어 UI")]
    public MainScoreUI mainScoreUI;

    private void Start()
    {
        if (mainScoreUI != null)
        {
            // 항상 꺼둠
            mainScoreUI.gameObject.SetActive(false);

            // 더스택에서 돌아온 경우만 점수 표시
            if (ScoreManager.Instance != null && ScoreManager.Instance.HasReturnedFromGame)
            {
                mainScoreUI.SetScore(ScoreManager.Instance.BestScore, ScoreManager.Instance.BestCombo);
                mainScoreUI.gameObject.SetActive(true);

                // 플래그 초기화
                ScoreManager.Instance.ResetReturnFlag();
            }
        }
    }
}
