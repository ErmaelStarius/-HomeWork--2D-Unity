using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private Text dialogName;
    public GameObject dialog; // �ش� NPC��ȭ

    void Start()
    {
        dialogName.text = name;
    }
}
