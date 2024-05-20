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

    private void Awake()
    {
        UpdateCharacterStatus();
    }

    private void Start()
    {
        
    }

    private void UpdateCharacterStatus()
    {
        AttackSO attackSO = null;

        if(baseStatus.attackSO != null)
        {
            attackSO = Instantiate(baseStatus.attackSO);
        }

        // [�������] �⺻ �ɷ�ġ�� ������ �ȴ�.
        currentStatus = new CharacterStatus { attackSO = attackSO };

        currentStatus.statusChangeType = baseStatus.statusChangeType;
        currentStatus.maxHealth = baseStatus.maxHealth;
        currentStatus.speed = baseStatus.speed;
    }
}