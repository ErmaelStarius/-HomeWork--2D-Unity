using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatusHandler characterStatusHandler;

    private Vector2 movementDirection = Vector2.zero;

    // 넉백 구현
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    // 내 컴포넌트 안에서 끝난다.
    private void Awake()
    {
        // controller 와 TopDownMovement 는 같은 게임 오브젝트 안에 있다.
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatusHandler = GetComponent<CharacterStatusHandler>();

    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    // 물리작용 업데이트 관련된 내용 포함
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);

        // 넉백 구현
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    // 넉백 구현
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * characterStatusHandler.currentStatus.speed;

        // 넉백 구현
        if (knockbackDuration > 0.0f)
        {
            direction += knockback;
        }

        movementRigidbody.velocity = direction;
    }


}