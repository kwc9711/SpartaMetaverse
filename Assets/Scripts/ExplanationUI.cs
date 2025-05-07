using UnityEngine;
using UnityEngine.UI;

public class ExplanationUI : MonoBehaviour
{
    public GameObject explanationPanel; // 이 오브젝트 자체를 할당해도 됨
    public GameObject homeUI;           // HomeUI를 담은 오브젝트 (비활성 상태일 것)

    void Start()
    {
        // 버튼 컴포넌트가 반드시 붙어 있어야 함
        GetComponent<Button>().onClick.AddListener(CloseExplanation);
    }

    void CloseExplanation()
    {
        explanationPanel.SetActive(false); // 설명 패널 숨기기
        homeUI.SetActive(true);            // 홈 UI 보이기
    }
}
