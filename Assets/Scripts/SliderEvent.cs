using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderEvent : MonoBehaviour
{
    private Slider _slider;
    
    public event Action<float> ChangedReadings; 

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value) =>
        ChangedReadings?.Invoke(value);
}
