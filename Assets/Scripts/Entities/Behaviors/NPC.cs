using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private string name;
    //[SerializeField] private GameObject panel;
    //[SerializeField] private Text nameText;
    [SerializeField] private Text dialogName;

    private Camera camera;
    private Vector3 distance;
    public GameObject dialog; // 해당 NPC대화

    void Start()
    {
        //camera = Camera.main;
        // NPC 스프라이트와 겹치면 안되기 때문에 y축 길이 추가
        //distance = new Vector3(0, 0.8f, 0);

        // NPC 이름 UI에 출력
        dialogName.text = name;
    }

    private void Update()
    {
        // 패널의 위치는 World 위치이므로 계속 값을 변경해 줘야함
        //Vector2 textpos = transform.position + distance;
        //panel.transform.position = camera.WorldToScreenPoint(textpos);
    }
}
