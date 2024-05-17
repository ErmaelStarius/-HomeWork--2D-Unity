using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Text stageTime;
    [SerializeField] private Text stageText;
    [SerializeField] private GameObject startButton;
    private int stageLevel = 0;
    private float sec;
    private float min;

    void Update()
    {
        stageTime.text = min + " : " + sec.ToString("N0");
        GameTime();
    }

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

        // ���� �ð� Ȱ��ȭ
        stageTime.gameObject.SetActive(true);

        // ���� �ð��� ����
        sec = 30;
        min = 1;
    }

    public void StageClear()
    {
        // ���� �ð��� ����
        stageTime.gameObject.SetActive(false);
        startButton.SetActive(true);
    }

    public void StageFail()
    {
        // ���� �ð��� ����
    }
}
