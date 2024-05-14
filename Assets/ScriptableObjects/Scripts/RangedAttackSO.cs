 using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackSO", menuName = "TopDownController/Attacks/Ranged", order = 1)]

public class RangedAttackSO : AttackSO
{
    [Header("RangedAttack Info")]
    public string _BulletNameTag;
    public float _Duration;
    public float _Spread;
    public int _NumberOfProjectilesPerShot;
    public float _MultipleProjectilesAngle;
    public Color _ProjectileColor;
}

