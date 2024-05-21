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

    [Header("Player Status")]
    public CharacterStatusHandler characterStatusHandler;
    private int currency; // ȭ�� �ý����� ���� ����

    private void Start()
    {
        UpdateUpgradeTexts();
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
        shopGoldText.text = characterStatusHandler.currentStatus.gold + "G";
    }

    public void UpgradeAttackPower()
    {
        var attackSO = characterStatusHandler.currentStatus.attackSO;
        if (CanAffordUpgrade(500)) // ���׷��̵� ���
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
        if (CanAffordUpgrade(500)) // ���׷��̵� ���
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
        if (CanAffordUpgrade(500)) // ���׷��̵� ���
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
