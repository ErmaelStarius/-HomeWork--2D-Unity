using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Rigidbody2D rigidbody;
    public bool playerCheck = false;
    private CharacterStatusHandler player;
    private CharacterStatusHandler enemy;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterStatusHandler>();
        enemy = GetComponent<CharacterStatusHandler>();
        healthSystem = GetComponent<HealthSystem>();
        rigidbody = GetComponent<Rigidbody2D>();
        // 실제 실행 주체는 healthSystem임
        healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {
        // 멈추도록 수정
        rigidbody.velocity = Vector3.zero;

        // 약간 반투명한 느낌으로 변경
        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        // 스크립트 더이상 작동 안하도록 함
        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        // 적이라면
        if (playerCheck == false)
        {
            player.currentStatus.gold += enemy.currentStatus.gold;
        }

        // 2초뒤에 파괴
        Destroy(gameObject, 2f);
    }
}