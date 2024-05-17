using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatusHandler : MonoBehaviour
{
    // �⺻ �������ͽ��� �߰� �������ͽ��� ����ؼ� ���� �������ͽ��� ����ϴ� ����
    // ������ �⺻ �������ͽ��� ���.

    [SerializeField] private CharacterStatus baseStatus;

    public CharacterStatus _CurrentStatus { get; private set; }

    public List<CharacterStatus> _StatusModifiers = new List<CharacterStatus>();

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
        _CurrentStatus = new CharacterStatus { attackSO = attackSO };

        _CurrentStatus.statusChangeType = baseStatus.statusChangeType;
        _CurrentStatus.maxHealth = baseStatus.maxHealth;
        _CurrentStatus.speed = baseStatus.speed;
    }
}