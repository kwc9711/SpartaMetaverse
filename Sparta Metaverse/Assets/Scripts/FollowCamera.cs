using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (르탄이)
    public float smoothSpeed = 0.125f;

    public float minX = -25f;
    public float maxX = 25f;
    public float minY = -25f;
    public float maxY = 25f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z; // 카메라는 Z 고정

        // 경계 제한 적용
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // 부드럽게 따라가기
        Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = smoothedPos;
    }
}
