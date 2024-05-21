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
    public event Action OnTalkEvent;


    protected bool IsAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;


    protected CharacterStatusHandler status { get; private set; }

    protected virtual void Awake()
    {
        status = GetComponent<CharacterStatusHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }


    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < status.currentStatus.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking && timeSinceLastAttack >= status.currentStatus.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(status.currentStatus.attackSO);

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

    private void CallTalkEvent()
    {
        OnTalkEvent?.Invoke();
    }
}
