using UnityEngine;

public enum StatusChangeType
{
    Add = 0,
    Multiple = 1,
    Override = 2,
}


//  �����͸� ����ó�� ����� �� �ְ� ������ִ� �Ӽ� ����
[System.Serializable]

public class CharacterStatus
{
    public StatusChangeType statusChangeType;

    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
    public int gold; //�÷��̾� ���
    public float attackPower; //�÷��̾� ���ݷ�
    public Weapon equippedWeapon; //������ ���� ����
}