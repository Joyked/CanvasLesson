using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    private const string OverallSound = "OverallSound";
    private const string BackgroundMusic = "BackgroundMusic";
    private const string ButtonSound = "ButtonSound";
    
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private SliderEvent _backgroundSlider;
    [SerializeField] private SliderEvent _soundSlider;
    [SerializeField] private SliderEvent _overallSlider;
    [SerializeField] private Button _buttonToggle;
    
    private bool _soundIsEnable;

    private void Awake()
    {
        _buttonToggle.onClick.AddListener(ToggleAudio);
        _backgroundSlider.ChangedReadings += BackgroundMusicVolume;
        _soundSlider.ChangedReadings += SoundVolume;
        _overallSlider.ChangedReadings += OverallVolume;
    }

    private void OnDisable()
    {
        _buttonToggle.onClick.RemoveListener(ToggleAudio);
        _backgroundSlider.ChangedReadings -= BackgroundMusicVolume;
        _soundSlider.ChangedReadings -= SoundVolume;
        _overallSlider.ChangedReadings -= OverallVolume;
    }

    private void ToggleAudio()
    {
        if (_soundIsEnable)
            _mixerGroup.audioMixer.SetFloat(OverallSound, 0);
        else
            _mixerGroup.audioMixer.SetFloat(OverallSound, -80);

        _soundIsEnable = !_soundIsEnable;
    }

    private void BackgroundMusicVolume(float volume) =>
        _mixerGroup.audioMixer.SetFloat(BackgroundMusic, Mathf.Log10(volume) * 20);

    private void SoundVolume(float volume) =>
        _mixerGroup.audioMixer.SetFloat(ButtonSound, Mathf.Log10(volume) * 20);

    private void OverallVolume(float volume) =>
        _mixerGroup.audioMixer.SetFloat(OverallSound, Mathf.Log10(volume) * 20);
}
