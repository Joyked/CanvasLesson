using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
        _button.onClick.AddListener(Play);
    }

    private void Play() =>
        _audioSource.Play();
}
