using System;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
public class SizeChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const string IsPulsing = nameof(IsPulsing);
    private readonly int IsPulsingID = Animator.StringToHash(IsPulsing);
    
    private Animator _animator;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    public void OnPointerEnter(PointerEventData eventData) =>
        _animator.SetBool(IsPulsingID, true);

    public void OnPointerExit(PointerEventData eventData) =>
        _animator.SetBool(IsPulsingID, false);
}

