using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class HealText : PainterHealBase
{
    private TextMeshProUGUI _text;

    private void Awake() =>
        _text = GetComponent<TextMeshProUGUI>();

    protected override void DrawHealth() =>
        _text.text = $"{_health.HealthPoint}/{_health.MaxHealthPoint}";
}
