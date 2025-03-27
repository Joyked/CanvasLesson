using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundButton : MonoBehaviour
{
    public event Action ButtonPressed;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandlePressing);
    }

    private void HandlePressing() =>
        ButtonPressed?.Invoke();
}
