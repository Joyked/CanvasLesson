using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    private Button _button;
    private bool _isMusicOff;
    
    public event Action SwitchIsPressed;
    public event Action SwitchDontPressed;

    private void Awake() =>
        _button = GetComponent<Button>();

    private void OnEnable() =>
        _button.onClick.AddListener(ToggleMusic);

    private void OnDisable() =>
        _button.onClick.RemoveListener(ToggleMusic);

    private void ToggleMusic()
    {
        if(_isMusicOff)
            OnMusic();
        else
            OffMusic();

        _isMusicOff = !_isMusicOff;
    }

    private void OffMusic() =>
        SwitchDontPressed?.Invoke();

    private void OnMusic() =>
        SwitchIsPressed?.Invoke();
}
