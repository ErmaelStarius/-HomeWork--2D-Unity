using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    // Action 이 들어가는 함수는 void 만 반환해야 함
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;


    protected bool IsAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;


    protected CharacterStatusHandler _Status { get; private set; }

    protected virtual void Awake()
    {
        _Status = GetComponent<CharacterStatusHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }


    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack < _Status._CurrentStatus.attackSO._Delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking && timeSinceLastAttack >= _Status._CurrentStatus.attackSO._Delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(_Status._CurrentStatus.attackSO);

        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        // Invoke 값이 없으면 pass, 값이 있으면 실행
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        // Invoke 값이 없으면 pass, 값이 있으면 실행
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
