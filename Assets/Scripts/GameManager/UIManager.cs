using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("Upgrade Texts")]
    public Text attackPowerText;
    public Text attackSpeedText;
    public Text projectileSpeedText;
    public Text projectileCountText;
    public Text shopGoldText;
    public Text playerSpeedText;
    public Text healthHealText;
    public Text maxHealthText;
    public Image healthImg;

    [Header("Player Status")]
    public CharacterStatusHandler characterStatusHandler;

    private void Start()
    {
        UpdateUpgradeTexts();
    }

    private void Update()
    {
        healthImg.fillAmount = (float)characterStatusHandler.currentStatus.currentHealth / characterStatusHandler.currentStatus.maxHealth;
        if (attackPowerText.gameObject.activeSelf)
        {
            UpdateUpgradeTexts();
        }
    }

    private void UpdateUpgradeTexts()
    {
        attackPowerText.text = "공격력: " + characterStatusHandler.currentStatus.attackSO.power.ToString();
        attackSpeedText.text = "공격 속도: " + characterStatusHandler.currentStatus.attackSO.delay.ToString();
        projectileSpeedText.text = "투사체 속도: " + characterStatusHandler.currentStatus.attackSO.speed.ToString();
        if (characterStatusHandler.currentStatus.attackSO != null)
        {
            projectileCountText.text = "투사체 개수: " + characterStatusHandler.currentStatus.attackSO.numberOfProjectilesPerShot.ToString();
        }
        shopGoldText.text = "현재 골드:  " + characterStatusHandler.currentStatus.gold + "G";
        playerSpeedText.text = "이동 속도:   " + characterStatusHandler.currentStatus.speed.ToString(); //이동 속도
        healthHealText.text = "현재 체력:  " + characterStatusHandler.currentStatus.currentHealth.ToString(); //체력회복
        maxHealthText.text = "최대 체력:  " + characterStatusHandler.currentStatus.maxHealth.ToString();//최대 체력
    }

    public void UpgradeAttackPower()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(1000)) // 업그레이드 비용
        {
            attackSO.power += 1; // 공격력 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }

    public void UpgradeAttackSpeed()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(200)) // 업그레이드 비용
        {
            attackSO.delay = Mathf.Max(0.1f, attackSO.delay - 0.1f); // 공격 속도 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }

    public void UpgradeProjectileSpeed()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(200)) // 업그레이드 비용
        {
            attackSO.speed += 1; // 투사체 속도 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }

    public void UpgradeProjectileCount()
    {
        var rangedAttackSO = characterStatusHandler.currentStatus.attackSO;
        if (rangedAttackSO != null && CanAffordUpgrade(500)) // 업그레이드 비용
        {
            rangedAttackSO.numberOfProjectilesPerShot += 1; // 투사체 개수 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다");
        }
    }

    public void UpgradePlayerSpeed()
    {
        if (CanAffordUpgrade(1000)) // 업그레이드 비용
        {
            characterStatusHandler.currentStatus.speed += 1; // 이동 속도 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }
    public void UpgradeHealthRecovery()
    {
        if (CanAffordUpgrade(100)) // 업그레이드 비용
        {
            characterStatusHandler.currentStatus.currentHealth += characterStatusHandler.currentStatus.healthHeal; // 체력 회복 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }
    public void UpgradeMaxHealth()
    {
        if (CanAffordUpgrade(150)) // 업그레이드 비용
        {
            characterStatusHandler.currentStatus.maxHealth += 2; // 최대 체력 증가
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("화폐가 부족합니다.");
        }
    }

    private bool CanAffordUpgrade(int upgradeCost)
    {
        if (characterStatusHandler.currentStatus.gold >= upgradeCost)
        {
            characterStatusHandler.currentStatus.gold -= upgradeCost;
            return true;
        }
        return false;
    }

    
}
