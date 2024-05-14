using UnityEngine;


[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "TopDownController/Attacks/Default", order = 0)]

public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float _Size;
    public float _Delay;
    public float _Power;
    public float _Speed;
    public LayerMask _Target;

    [Header("KnockBack Info")]
    public bool isKnockBack;
    public float _KnockBackPower;
    public float _KnockBackTime;
}
