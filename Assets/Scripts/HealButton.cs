using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _heal;

    private Button _button;

    private void Awake() =>
        _button = GetComponent<Button>();
    
    private void OnEnable() =>
        _button.onClick.AddListener(Heal);

    private void OnDisable() =>
        _button.onClick.RemoveListener(Heal);

    private void Heal() =>
        _health.Heal(_heal);
}
