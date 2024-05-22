using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterStatusHandler : MonoBehaviour
{
    // 기본 스테이터스와 추가 스테이터스를 계산해서 최종 스테이터스를 계산하는 로직
    // 지금은 기본 스테이터스만 계산.

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
        // TODO : 지금은 기본 능력치만 적용되지만, 앞으로는 능력치 강화 기능이 적용됨
        currentStatus.statusChangeType = baseStatus.statusChangeType;
        currentStatus.maxHealth = baseStatus.maxHealth;
        currentStatus.speed = baseStatus.speed;
        currentStatus.gold = baseStatus.gold;
        currentStatus.currentHealth = baseStatus.maxHealth;
        currentStatus.healthHeal = baseStatus.healthHeal;
    }
}