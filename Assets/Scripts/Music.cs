using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    protected AudioSource AudioSource;
    
    private SoundSwitch _soundSwitch;
    private SliderEvent _sliderMusic;
    private SliderEvent _sliderOverall;
    private float _volumeMusicInSliderMusic = 1;
    private float _volumeMusicInSliderOverall = 1;

    public void Initialize(SliderEvent sliderMusic, SliderEvent sliderOverall, SoundSwitch soundSwitch)
    {
        AudioSource = GetComponent<AudioSource>();
        _sliderMusic = sliderMusic;
        _sliderOverall = sliderOverall;
        _soundSwitch = soundSwitch;
        _soundSwitch.SwitchIsPressed += Unmute;
        _soundSwitch.SwitchDontPressed += Anmute;
        _sliderMusic.ChangedReadings += ChangeVolumeMusic;
        _sliderOverall.ChangedReadings += ChangeVolumeOverall;
    }
    
    private void Anmute() =>
        AudioSource.mute = true;

    private void Unmute() =>
        AudioSource.mute = false;

    private void OnDisable() =>
        Unsubscribe();

    protected virtual void Unsubscribe()
    {
        _sliderMusic.ChangedReadings -= ChangeVolumeMusic;
        _sliderOverall.ChangedReadings -= ChangeVolumeOverall;
        _soundSwitch.SwitchIsPressed -= Unmute;
        _soundSwitch.SwitchDontPressed -= Anmute;
    }
    
    private void ChangeVolumeMusic(float volume)
    {
        _volumeMusicInSliderMusic = volume;
        AudioSource.volume = volume * _volumeMusicInSliderOverall;
    }

    private void ChangeVolumeOverall(float volume)
    {
        _volumeMusicInSliderOverall = volume;
        AudioSource.volume = volume * _volumeMusicInSliderMusic;
    }
}
