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
        // ���� ���� ��ü�� healthSystem��
        healthSystem.OnDeath += OnDeath;
    }

    void OnDeath()
    {
        // ���ߵ��� ����
        rigidbody.velocity = Vector3.zero;

        // �ణ �������� �������� ����
        foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        // ��ũ��Ʈ ���̻� �۵� ���ϵ��� ��
        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        // ���̶��
        if (playerCheck == false)
        {
            player.currentStatus.gold += enemy.currentStatus.gold;
        }

        // 2�ʵڿ� �ı�
        Destroy(gameObject, 2f);
    }
}