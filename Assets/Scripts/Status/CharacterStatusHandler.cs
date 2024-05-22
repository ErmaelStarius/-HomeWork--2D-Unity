using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterStatusHandler : MonoBehaviour
{
    // �⺻ �������ͽ��� �߰� �������ͽ��� ����ؼ� ���� �������ͽ��� ����ϴ� ����
    // ������ �⺻ �������ͽ��� ���.

    [SerializeField] private CharacterStatus baseStatus;
    [SerializeField] private Text goldText;

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

    private void Update()
    {
        StatusUpdate();
    }

    private void StatusUpdate()
    {
        if (goldText != null)
        {
            goldText.text = currentStatus.gold + "G";
        }
    }

    private void UpdateCharacterStatus()
    {
        RangedAttackSO attackSO = null;
        if (baseStatus.attackSO != null)
        {
            attackSO = Instantiate(baseStatus.attackSO);
        }

        currentStatus = new CharacterStatus { attackSO = attackSO };
        // TODO : ������ �⺻ �ɷ�ġ�� ���������, �����δ� �ɷ�ġ ��ȭ ����� �����
        currentStatus.statusChangeType = baseStatus.statusChangeType;
        currentStatus.maxHealth = baseStatus.maxHealth;
        currentStatus.speed = baseStatus.speed;
        currentStatus.gold = baseStatus.gold;
        currentStatus.currentHealth = baseStatus.maxHealth;
        currentStatus.healthHeal = baseStatus.healthHeal;
    }
}