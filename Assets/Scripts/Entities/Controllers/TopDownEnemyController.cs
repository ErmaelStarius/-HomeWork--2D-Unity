using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownEnemyController : TopDownController
{
    protected Transform closestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        closestTarget = GameManager.Instance.player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, closestTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (closestTarget.position - transform.position).normalized;
    }
}
