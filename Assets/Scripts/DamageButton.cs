using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _damage;

    private Button _button;

    private void Awake() =>
        _button = GetComponent<Button>();

    private void OnEnable() =>
        _button.onClick.AddListener(TransferDamage);

    private void OnDisable() =>
        _button.onClick.RemoveListener(TransferDamage);

    private void TransferDamage() =>
        _health.TakeDamage(_damage);
}
