using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("이동 속도")]
    public float moveSpeed = 5f;

    [Header("카메라 이동 경계 (맵 안에서만 움직이게 하고 싶다면 사용)")]
    public float minX = -25f;
    public float maxX = 25f;
    public float minY = -25f;
    public float maxY = 25f;

    private Vector2 moveInput;
    private Vector2 lookDirection;
    private Camera mainCam;
    private SpriteRenderer sr;

    private void Awake()
    {
        mainCam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // 이동
        Vector3 move = moveInput * moveSpeed * Time.deltaTime;
        Vector3 newPos = transform.position + (Vector3)move;

        // 경계 제한
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        transform.position = newPos;

        // 마우스 방향 보기 (스프라이트 플립)
        if (lookDirection.x > 0.1f)
            sr.flipX = false;
        else if (lookDirection.x < -0.1f)
            sr.flipX = true;
    }

    // Input System: Player/Move (2D Vector)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Input System: Player/Look (Vector2 → Mouse Position)
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseScreenPos = context.ReadValue<Vector2>();

        if (mainCam == null) return;

        Vector2 worldMousePos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        lookDirection = worldMousePos - (Vector2)transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MiniGame")
        {
            SceneManager.LoadScene("TheStackScene"); // 복사한 씬 이름 정확히 입력!
        }
    }


}
