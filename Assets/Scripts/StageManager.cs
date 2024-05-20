//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Text stageTime; // �������� ���� �ð�
    [SerializeField] private Text stageText; // ���� �������� �ؽ�Ʈ
    [SerializeField] private Button startButton;  // �������� ���� ��ư
    [SerializeField] private GameObject[] spawnPos;   // ���� ���� ��ġ
    [SerializeField] private GameObject entranceTile; // ���� �Ա�
    [SerializeField] private GameObject player;
    private int stageLevel = 0; // �������� ����
    private float sec; // ���� �ð�(��)
    private float min; // ���� �ð�(��)

    void Update()
    {
        stageTime.text = min + " : " + sec.ToString("N0");
        // �ð� ����
        GameTime();

        // ���� ��ư Ȱ��ȭ
        StartButtonActive();   
    }

    // �÷��̾��� ��ġ�� ���� ��ư Ȱ��ȭ
    private void StartButtonActive()
    {
        if (startButton.gameObject.activeSelf && player.transform.position.y > 6)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }
    }

    // �ð��� ������ �����ϰ� ��
    private void GameTime()
    {
        if(min >= 0)
        {
            sec -= Time.deltaTime;
            if (sec < 0)
            {
                min -= 1;
                sec = 59;
            }
        }
        else
        {
            StageClear();
        }
    }

    public void StageStart()
    {
        // �������� ���� ���
        stageLevel++;
        stageText.text = "Stage " + stageLevel;

        // ���� ���� ����
        StartCoroutine("MonsterSpawn");

        // ���� �ð� �ؽ�Ʈ Ȱ��ȭ
        stageTime.gameObject.SetActive(true);

        // ���� �Ա� ��Ȱ��ȭ
        entranceTile.gameObject.SetActive(true);

        // ���� �ð��� ����
        sec = 30;
        min = 1;
    }

    public void StageClear()
    {
        // ���� �ð��� ����
        stageTime.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        // ���� ���� ����
        StopCoroutine("MonsterSpawn");

        // ���� �Ա� Ȱ��ȭ
        entranceTile.gameObject.SetActive(false);

        // Ŭ��� ���� ���� ���� ��Ȱ��ȭ
        GameManager.Instance.MonsterDestroy();
    }

    public void StageFail()
    {
        // ���� �ð��� ����
    }

    // �ش� ���͸� �����ϴ� �ڷ�ƾ
    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            // ������ ��ġ �������� ����
            int result = Random.Range(0, 3);
            // �ش� ���� �±׸�
            GameObject obj = GameManager.Instance.objectPool.SpawnFromPool("Slime");

            // ���� ��ġ�� ���� 3������ ���� ������ ��ġ�� �̵�
            obj.transform.position = spawnPos[result].transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
