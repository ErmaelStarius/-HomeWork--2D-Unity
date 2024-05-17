using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatusHandler : MonoBehaviour
{
    // �⺻ �������ͽ��� �߰� �������ͽ��� ����ؼ� ���� �������ͽ��� ����ϴ� ����
    // ������ �⺻ �������ͽ��� ���.

    [SerializeField] private CharacterStatus baseStatus;

    public CharacterStatus BaseStatus
    {
        get { return baseStatus; }
        set 
        { 
            baseStatus = value;
            UpdateCharacterStatus();
        }
    }
    public CharacterStatus _CurrentStatus { get; private set; }

    public List<CharacterStatus> _StatusModifiers = new List<CharacterStatus>();

    private void Awake()
    {
        UpdateCharacterStatus();
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
        _CurrentStatus = new CharacterStatus 
        {

            //�÷��̾� ����
            attackSO = attackSO,
            statusChangeType = baseStatus.statusChangeType,
            maxHealth = baseStatus.maxHealth,
            speed = baseStatus.speed,
            gold = baseStatus.gold,
            attackPower = baseStatus.attackPower

        };

        
    }
}