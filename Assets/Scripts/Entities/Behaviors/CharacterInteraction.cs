using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    // 상호작용 가능할 때 보이는 키
    [SerializeField] private GameObject interaction;

    private TopDownController controller;
    private GameObject dialog = null;

    void Start()
    {
        controller = GetComponent<TopDownController>();
        controller.OnTalkEvent += NPCTalk;
    }
 
    // 상호작용 키의 활성화에 따라서 대화창 활성화
    private void NPCTalk()
    {
        if (interaction.activeSelf)
        {
            dialog.SetActive(true);
        }
    }

    // NPC와 가까워졌을 때 상호작용 키 활성화
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            interaction.SetActive(true);
            dialog = collision.GetComponent<NPC>()?.dialog;
        }
    }

    // NPC와 멀어졌을 때 상호작용 키 비활성화
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc"))
        {
            interaction.SetActive(false);
        }
    }
}
