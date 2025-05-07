using UnityEngine;
using UnityEngine.UI;

public class ExplanationUI : MonoBehaviour
{
    public GameObject explanationPanel; // �� ������Ʈ ��ü�� �Ҵ��ص� ��
    public GameObject homeUI;           // HomeUI�� ���� ������Ʈ (��Ȱ�� ������ ��)

    void Start()
    {
        // ��ư ������Ʈ�� �ݵ�� �پ� �־�� ��
        GetComponent<Button>().onClick.AddListener(CloseExplanation);
    }

    void CloseExplanation()
    {
        explanationPanel.SetActive(false); // ���� �г� �����
        homeUI.SetActive(true);            // Ȩ UI ���̱�
    }
}
