using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusInitializer : MonoBehaviour
{
    [SerializeField] private CharacterStatusHandler characterStatusHandler;

    private void Start()
    {
        // 기본 상태 설정
        CharacterStatus baseStatus = new CharacterStatus
        {
            speed = 5.0f,
            maxHealth = 100,
            attackPower = 20.0f,
            gold = 50
        };

        characterStatusHandler.BaseStatus = baseStatus;
        characterStatusHandler.UpdateCharacterStatus();
    }
}
