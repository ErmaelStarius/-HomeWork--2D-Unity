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
    public GameObject dialog; // �ش� NPC��ȭ

    void Start()
    {
        //camera = Camera.main;
        // NPC ��������Ʈ�� ��ġ�� �ȵǱ� ������ y�� ���� �߰�
        //distance = new Vector3(0, 0.8f, 0);

        // NPC �̸� UI�� ���
        dialogName.text = name;
    }

    private void Update()
    {
        // �г��� ��ġ�� World ��ġ�̹Ƿ� ��� ���� ������ �����
        //Vector2 textpos = transform.position + distance;
        //panel.transform.position = camera.WorldToScreenPoint(textpos);
    }
}
