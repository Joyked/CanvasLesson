using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour
{
    public event Action<float> ChangedReadings; 
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value) =>
        ChangedReadings?.Invoke(value);
}
