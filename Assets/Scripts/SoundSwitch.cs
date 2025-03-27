using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    public event Action SwitchIsPressed;
    public event Action SwitchDontPressed;
    
    private Button _button;
    private bool _isMusicOff;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleMusic);
    }

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
