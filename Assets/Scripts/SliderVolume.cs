using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public event Action<float> ChangedReadings; 

    private void OnEnable() =>
        _slider.onValueChanged.AddListener(ChangeVolume);

    private void OnDisable() =>
        _slider.onValueChanged.RemoveListener(ChangeVolume);

    private void ChangeVolume(float value) =>
        ChangedReadings?.Invoke(value);
}
