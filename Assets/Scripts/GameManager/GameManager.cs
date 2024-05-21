using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag = "Player";

    public ObjectPool objectPool { get; private set; }
    public Transform player {  get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;

        objectPool = GetComponent<ObjectPool>();


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
