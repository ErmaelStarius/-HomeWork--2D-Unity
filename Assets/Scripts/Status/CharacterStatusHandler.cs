using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterStatusHandler : MonoBehaviour
{
    // 기본 스테이터스와 추가 스테이터스를 계산해서 최종 스테이터스를 계산하는 로직
    // 지금은 기본 스테이터스만 계산.

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

        // [현재상태] 기본 능력치만 적용이 된다.
        _CurrentStatus = new CharacterStatus 
        {

            //플레이어 정보
            attackSO = attackSO,
            statusChangeType = baseStatus.statusChangeType,
            maxHealth = baseStatus.maxHealth,
            speed = baseStatus.speed,
            gold = baseStatus.gold,
            attackPower = baseStatus.attackPower

        };

        
    }
}