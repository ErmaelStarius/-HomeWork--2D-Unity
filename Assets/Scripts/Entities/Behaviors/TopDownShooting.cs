using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject TestPrefab;

    private ObjectPool pool;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot;

        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;

        if(rangedAttackSO == null)
        {
            return;
        }

        float projectilesAngleSpace = rangedAttackSO._MultipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangedAttackSO._NumberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackSO._MultipleProjectilesAngle;

        for(int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;

            float randomSpread = Random.Range(-rangedAttackSO._Spread, rangedAttackSO._Spread);

            angle += randomSpread;

            CreatProjectile(rangedAttackSO,angle);
        }
    }

    private void CreatProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
       //GameObject obj = pool.SpawnFromPool(rangedAttackSO._BulletNameTag);
        GameObject obj = Instantiate(TestPrefab);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(rotateVector2(aimDirection,angle), rangedAttackSO);

        // Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }

    private static Vector2 rotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
