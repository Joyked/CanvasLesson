using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FastSlider : PainterHealBase
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.MaxHealthPoint;
    }

    protected override void DrawHealth() =>
        _slider.value = _health.HealthPoint;
}
