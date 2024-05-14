using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private float _Speed;

    Rigidbody2D _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �� �����Ӹ��� Vertical ��� Horizontal ���� �����ɴϴ�.
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        // [�ʱ�ȭ] ���� ���� �� �� ����
        Vector2 direction = new Vector2(horizontal, vertical);

        // [����ȭ] ��� ������ ���̸� 1�� ����� ����
        direction = direction.normalized;

        _Rigidbody.velocity = direction * _Speed;
    }
}
