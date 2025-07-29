using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _button.onClick.AddListener(Recolor);
    }

    private void Recolor()
    {
        float rChaтnel = Random.Range(0.1f, 1f);
        float gChaтnel = Random.Range(0.1f, 1f);
        float bChaтnel = Random.Range(0.1f, 1f);

        _image.color = new Color(rChaтnel, gChaтnel, bChaтnel);
    }
}
