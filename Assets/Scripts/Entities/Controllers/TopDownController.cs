using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    // Action �� ���� �Լ��� void �� ��ȯ�ؾ� ��
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
        // Invoke ���� ������ pass, ���� ������ ����
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        // Invoke ���� ������ pass, ���� ������ ����
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
