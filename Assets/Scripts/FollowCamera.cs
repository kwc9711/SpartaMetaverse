using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // ���� ��� (��ź��)
    public float smoothSpeed = 0.125f;

    public float minX = -25f;
    public float maxX = 25f;
    public float minY = -25f;
    public float maxY = 25f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z; // ī�޶�� Z ����

        // ��� ���� ����
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // �ε巴�� ���󰡱�
        Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
