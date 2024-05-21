using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;

    }


    public void OnMove(InputValue value)
    {
        // 초기화 및 정규화
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        // 실제 움직이는 처리는 PlayerMovement 에서 한다.

    }


    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
