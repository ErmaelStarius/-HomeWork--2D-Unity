//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Text stageTime; // 스테이지 남은 시간
    [SerializeField] private Text stageText; // 현재 스테이지 텍스트
    [SerializeField] private Button startButton;  // 스테이지 시작 버튼
    [SerializeField] private GameObject[] spawnPos;   // 몬스터 스폰 위치
    [SerializeField] private GameObject entranceTile; // 상점 입구
    [SerializeField] private GameObject player;
    private int stageLevel = 0; // 스테이지 레벨
    private float sec; // 게임 시간(초)
    private float min; // 게임 시간(분)

    void Update()
    {
        stageTime.text = min + " : " + sec.ToString("N0");
        // 시간 진행
        GameTime();

        // 시작 버튼 활성화
        StartButtonActive();   
    }

    // 플레이어의 위치에 따라서 버튼 활성화
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

    // 시간이 있으면 감소하게 함
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
        // 스테이지 레벨 상승
        stageLevel++;
        stageText.text = "Stage " + stageLevel;

        // 몬스터 스폰 시작
        StartCoroutine("MonsterSpawn");

        // 게임 시간 텍스트 활성화
        stageTime.gameObject.SetActive(true);

        // 상점 입구 비활성화
        entranceTile.gameObject.SetActive(true);

        // 게임 시간을 감소
        sec = 30;
        min = 1;
    }

    public void StageClear()
    {
        // 게임 시간을 없앰
        stageTime.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        // 몬스터 스폰 중지
        StopCoroutine("MonsterSpawn");

        // 상점 입구 활성화
        entranceTile.gameObject.SetActive(false);

        // 클리어에 따른 남은 몬스터 비활성화
        GameManager.Instance.MonsterDestroy();
    }

    public void StageFail()
    {
        // 게임 시간을 멈춤
    }

    // 해당 몬스터를 스폰하는 코루틴
    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            // 스포너 위치 랜덤으로 정함
            int result = Random.Range(0, 3);
            // 해당 몬스터 태그명
            GameObject obj = GameManager.Instance.objectPool.SpawnFromPool("Slime");

            // 몬스터 위치를 랜덤 3가지의 몬스터 스포너 위치로 이동
            obj.transform.position = spawnPos[result].transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
