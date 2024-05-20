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

    public void UpdateCharacterStatus()
    {
        if (baseStatus == null)
        {
            Debug.LogError("BaseStatus is null.");
            return;
        }
        AttackSO attackSO = null;

        if(baseStatus.attackSO != null)
        {
            attackSO = Instantiate(baseStatus.attackSO);
        }

        // [�������] �⺻ �ɷ�ġ�� ������ �ȴ�.
        currentStatus = new CharacterStatus
        {
            attackSO = attackSO,
            statusChangeType = baseStatus.statusChangeType,
            maxHealth = baseStatus.maxHealth,
            speed = baseStatus.speed, //�÷��̾� ���ǵ�
            gold = baseStatus.gold, //�÷��̾� ���
            attackPower = baseStatus.attackPower, //�÷��̾� ���ݷ�
            equippedWeapon = baseStatus.equippedWeapon // ���� ����
        };
    }
}