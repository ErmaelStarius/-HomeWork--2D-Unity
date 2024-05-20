using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatusHandler : MonoBehaviour
{
    // 기본 스테이터스와 추가 스테이터스를 계산해서 최종 스테이터스를 계산하는 로직
    // 지금은 기본 스테이터스만 계산.

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

        // [현재상태] 기본 능력치만 적용이 된다.
        currentStatus = new CharacterStatus
        {
            attackSO = attackSO,
            statusChangeType = baseStatus.statusChangeType,
            maxHealth = baseStatus.maxHealth,
            speed = baseStatus.speed, //플레이어 스피드
            gold = baseStatus.gold, //플레이어 골드
            attackPower = baseStatus.attackPower, //플레이어 공격력
            equippedWeapon = baseStatus.equippedWeapon // 무기 정보
        };
    }
}