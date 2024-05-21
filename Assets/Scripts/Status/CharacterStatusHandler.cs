using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatusHandler : MonoBehaviour
{
    // �⺻ �������ͽ��� �߰� �������ͽ��� ����ؼ� ���� �������ͽ��� ����ϴ� ����
    // ������ �⺻ �������ͽ��� ���.

    [SerializeField] private CharacterStatus baseStatus;

    public CharacterStatus currentStatus { get; private set; }

    public List<CharacterStatus> statusModifiers = new List<CharacterStatus>();

    public CharacterStatus BaseStatus
    {
        get { return baseStatus; }
        set
        {
            baseStatus = value;
            UpdateCharacterStatus();
        }
    }
    private void Awake()
    {
        if (baseStatus != null)
        {
            UpdateCharacterStatus();
        }
    }

    private void Start()
    {
        
    }

    private void UpdateCharacterStatus()
    {
        AttackSO attackSO = null;
        if (baseStatus.attackSO != null)
        {
            attackSO = Instantiate(baseStatus.attackSO);
        }

        currentStatus = new CharacterStatus { attackSO = attackSO };
        // TODO : ������ �⺻ �ɷ�ġ�� ���������, �����δ� �ɷ�ġ ��ȭ ����� �����
        currentStatus.statusChangeType = baseStatus.statusChangeType;
        currentStatus.maxHealth = baseStatus.maxHealth;
        currentStatus.speed = baseStatus.speed;
    }
}