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
        attackPowerText.text = "���ݷ�: " + characterStatusHandler.currentStatus.attackSO.power.ToString();
        attackSpeedText.text = "���� �ӵ�: " + characterStatusHandler.currentStatus.attackSO.delay.ToString();
        projectileSpeedText.text = "����ü �ӵ�: " + characterStatusHandler.currentStatus.attackSO.speed.ToString();
        if (characterStatusHandler.currentStatus.attackSO != null)
        {
            projectileCountText.text = "����ü ����: " + characterStatusHandler.currentStatus.attackSO.numberOfProjectilesPerShot.ToString();
        }
        shopGoldText.text = "���� ���:  " + characterStatusHandler.currentStatus.gold + "G";
        playerSpeedText.text = "�̵� �ӵ�:   " + characterStatusHandler.currentStatus.speed.ToString(); //�̵� �ӵ�
        healthHealText.text = "���� ü��:  " + characterStatusHandler.currentStatus.currentHealth.ToString(); //ü��ȸ��
        maxHealthText.text = "�ִ� ü��:  " + characterStatusHandler.currentStatus.maxHealth.ToString();//�ִ� ü��
    }

    public void UpgradeAttackPower()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(1000)) // ���׷��̵� ���
        {
            attackSO.power += 1; // ���ݷ� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
        }
    }

    public void UpgradeAttackSpeed()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(200)) // ���׷��̵� ���
        {
            attackSO.delay = Mathf.Max(0.1f, attackSO.delay - 0.1f); // ���� �ӵ� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
        }
    }

    public void UpgradeProjectileSpeed()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(200)) // ���׷��̵� ���
        {
            attackSO.speed += 1; // ����ü �ӵ� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
        }
    }

    public void UpgradeProjectileCount()
    {
        var rangedAttackSO = characterStatusHandler.currentStatus.attackSO;
        if (rangedAttackSO != null && CanAffordUpgrade(500)) // ���׷��̵� ���
        {
            rangedAttackSO.numberOfProjectilesPerShot += 1; // ����ü ���� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�");
        }
    }

    public void UpgradePlayerSpeed()
    {
        if (CanAffordUpgrade(1000)) // ���׷��̵� ���
        {
            characterStatusHandler.currentStatus.speed += 1; // �̵� �ӵ� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
        }
    }
    public void UpgradeHealthRecovery()
    {
        if (CanAffordUpgrade(100)) // ���׷��̵� ���
        {
            characterStatusHandler.currentStatus.currentHealth += characterStatusHandler.currentStatus.healthHeal; // ü�� ȸ�� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
        }
    }
    public void UpgradeMaxHealth()
    {
        if (CanAffordUpgrade(150)) // ���׷��̵� ���
        {
            characterStatusHandler.currentStatus.maxHealth += 2; // �ִ� ü�� ����
            UpdateUpgradeTexts();
        }
        else
        {
            Debug.Log("ȭ�� �����մϴ�.");
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
