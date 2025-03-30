using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    private const string OverallSound = "OverallSound";
    private const string BackgroundMusic = "BackgroundMusic";
    private const string ButtonSound = "ButtonSound";
    
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private SliderVolume _backgroundSliderVolume;
    [SerializeField] private SliderVolume _soundSliderVolume;
    [SerializeField] private SliderVolume _overallSliderVolume;
    [SerializeField] private Button _buttonToggle;
    
    private bool _soundIsEnable;
    
    private void OnEnable()
    {
        _buttonToggle.onClick.AddListener(ToggleAudio);
        _backgroundSliderVolume.ChangedReadings += volume => SoundVolume(volume , BackgroundMusic);
        _soundSliderVolume.ChangedReadings += volume => SoundVolume(volume , ButtonSound);
        _overallSliderVolume.ChangedReadings += volume => SoundVolume(volume , OverallSound);
    }

    private void OnDisable()
    {
        _buttonToggle.onClick.RemoveListener(ToggleAudio);
        _backgroundSliderVolume.ChangedReadings -= volume => SoundVolume(volume , BackgroundMusic);
        _soundSliderVolume.ChangedReadings -= volume => SoundVolume(volume , ButtonSound);
        _overallSliderVolume.ChangedReadings -= volume=> SoundVolume(volume , OverallSound);
    }

    private void ToggleAudio()
    {
        if (_soundIsEnable)
            _mixerGroup.audioMixer.SetFloat(OverallSound, 0);
        else
            _mixerGroup.audioMixer.SetFloat(OverallSound, -80);

        _soundIsEnable = !_soundIsEnable;
    }

    private void SoundVolume(float volume, string sound)
    {
        if(volume > 0)
            _mixerGroup.audioMixer.SetFloat(sound, Mathf.Log10(volume) * 20);
        else
            _mixerGroup.audioMixer.SetFloat(sound, -80);
    }
}
