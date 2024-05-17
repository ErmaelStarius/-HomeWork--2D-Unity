using UnityEngine;

public enum StatusChangeType
{
    Add = 0,
    Multiple = 1,
    Override = 2,
}


//  데이터를 폴더처럼 사용할 수 있게 만들어주는 속성 제공
[System.Serializable]

public class CharacterStatus
{
    public StatusChangeType statusChangeType;

    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}