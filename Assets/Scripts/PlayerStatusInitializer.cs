using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusInitializer : MonoBehaviour
{
    [SerializeField] private CharacterStatusHandler characterStatusHandler;

    private void Start()
    {
        if (characterStatusHandler == null)
        {
            Debug.LogError("CharacterStatusHandler가 비어있음");
            return;
        }

        // 기본 상태 설정
        CharacterStatus baseStatus = new CharacterStatus
        {
            speed = 5.0f,
            maxHealth = 100,
            attackPower = 20.0f,
            gold = 50,
            equippedWeapon = new Weapon // 기본 무기 설정
            {
                attackPower = 10.0f,
                attackDelay = 1.0f,
                attackSpeed = 5.0f,
                price = 100
            }
        };

        characterStatusHandler.BaseStatus = baseStatus;
    }
}
