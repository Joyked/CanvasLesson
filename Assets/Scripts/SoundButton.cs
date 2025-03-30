using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class SoundButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() =>
        _button.onClick.AddListener(Play);

    private void OnDisable() =>
        _button.onClick.RemoveListener(Play);

    private void Play() =>
        _audioSource.Play();
}
