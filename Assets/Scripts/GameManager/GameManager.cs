using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private GameObject gameFailObject;

    public ObjectPool objectPool { get; private set; }
    public Transform player {  get; private set; }

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;

        objectPool = GetComponent<ObjectPool>();


    }

    public void GameFail()
    {
        // 게임 시간을 0으로 변경
        Time.timeScale = 0;
        gameFailObject.SetActive(true);
    }

    public void MonsterDestroy()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            GameObject parentObject = transform.GetChild(i).gameObject;
            foreach (Transform child in parentObject.transform)
            {
                GameObject monster = child.gameObject;
                monster.SetActive(false);
            }
        }
    }
}
