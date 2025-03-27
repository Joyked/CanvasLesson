using UnityEngine;

public class Bootstarp : MonoBehaviour
{
    [SerializeField] private Music[] _musics;
    [SerializeField] private Music _backgroundMusic;
    [SerializeField] private SliderEvent _overallVolumeSlider;
    [SerializeField] private SliderEvent _buttonVolumeSlider;
    [SerializeField] private SliderEvent _backgroundMusicSlider;
    [SerializeField] private SoundSwitch _soundSwitch;

    private void Awake()
    {
        foreach (var music in _musics)
            music.Initialize(_buttonVolumeSlider, _overallVolumeSlider, _soundSwitch);
        
        _backgroundMusic.Initialize(_backgroundMusicSlider, _overallVolumeSlider, _soundSwitch);
    }
}
