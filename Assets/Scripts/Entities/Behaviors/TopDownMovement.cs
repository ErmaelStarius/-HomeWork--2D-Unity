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
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * characterStatusHandler.currentStatus.speed;
        movementRigidbody.velocity = direction;
    }


}