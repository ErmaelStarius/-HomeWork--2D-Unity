using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private string playerTag;

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
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
