using UnityEngine;
using UnityEngine.UIElements;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Transform weaponPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownController controller;

    private void Awake()
    {
       controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateWeapon(direction);
    }

    private void RotateWeapon(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;

        weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
