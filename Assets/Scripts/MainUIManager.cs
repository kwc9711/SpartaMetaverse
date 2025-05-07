using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    [Header("���� �� ���ھ� UI")]
    public MainScoreUI mainScoreUI;

    private void Start()
    {
        if (mainScoreUI != null)
        {
            // �׻� ����
            mainScoreUI.gameObject.SetActive(false);

            // �����ÿ��� ���ƿ� ��츸 ���� ǥ��
            if (ScoreManager.Instance != null && ScoreManager.Instance.HasReturnedFromGame)
            {
                mainScoreUI.SetScore(ScoreManager.Instance.BestScore, ScoreManager.Instance.BestCombo);
                mainScoreUI.gameObject.SetActive(true);

                // �÷��� �ʱ�ȭ
                ScoreManager.Instance.ResetReturnFlag();
            }
        }
    }
}
