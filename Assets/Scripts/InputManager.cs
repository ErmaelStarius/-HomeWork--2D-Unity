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
        // 매 프레임마다 Vertical 축과 Horizontal 축을 가져옵니다.
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        // [초기화] 변수 선언 및 값 대입
        Vector2 direction = new Vector2(horizontal, vertical);

        // [정규화] 모든 방향의 길이를 1로 만드는 과정
        direction = direction.normalized;

        _Rigidbody.velocity = direction * _Speed;
    }
}
