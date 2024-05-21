using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem collidingTargetHealthSystem;
    private TopDownMovement collidingMovement;

    protected override void Start()
    {
        base.Start();

        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        followRange = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;

        if(DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject receiver = collision.gameObject;

        if (!receiver.CompareTag(targetTag))
        {
            return;
        }

        collidingTargetHealthSystem = receiver.GetComponent<HealthSystem>();
        if (collidingTargetHealthSystem != null)
        {
            isCollidingWithTarget = true;
        }

        collidingMovement = receiver.GetComponent<TopDownMovement>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        isCollidingWithTarget = false;
    }

    private void ApplyHealthChange()
    {
        AttackSO attackSO = status.currentStatus.attackSO;
        bool hasBeenChanged = collidingTargetHealthSystem.ChangeHealth(-attackSO.power);
        gameObject.SetActive(false);
        if (attackSO.isKnockBack && collidingMovement != null)
        {
            collidingMovement.ApplyKnockback(transform, attackSO.knockBackPower, attackSO.knockBackTime);
        }
    }
}