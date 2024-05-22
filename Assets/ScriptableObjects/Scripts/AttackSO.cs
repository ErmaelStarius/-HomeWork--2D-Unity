using UnityEngine;


[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "TopDownController/Attacks/Default", order = 0)]

public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public int power;
    public float speed;
    public LayerMask target;

    [Header("KnockBack Info")]
    public bool isKnockBack;
    public float knockBackPower;
    public float knockBackTime;
}
