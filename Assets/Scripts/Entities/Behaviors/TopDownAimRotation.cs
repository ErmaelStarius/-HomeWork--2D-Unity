using UnityEngine;
using UnityEngine.UIElements;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _WeaponRenderer;
    [SerializeField] private Transform _WeaponPivot;

    [SerializeField] private SpriteRenderer _CharacterRenderer;

    private TopDownController _Controller;

    private void Awake()
    {
       _Controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        _Controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateWeapon(direction);
    }

    private void RotateWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        _CharacterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

        _WeaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
