using Microsoft.MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScaleHandler : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float Cutoff = 0.1f;
    [SerializeField] private float SliderToScaleMultiplier = 2f;

    private Transform _bubbleTransform;
    private Vector3 _initialScale;

    private void Awake()
    {
        _bubbleTransform = gameObject.transform;
        _initialScale = _bubbleTransform.localScale;
    }

    private void Start()
    {
        _bubbleTransform.localScale = PlayerInfoSystem.Instance.BubbleRadius * Vector3.one;
        _bubbleTransform.gameObject.GetComponent<MeshRenderer>().enabled =
            PlayerInfoSystem.Instance.BubbleVisibility;
    }

    public void OnSliderValueUpdated(SliderEventData data)
    {
        float newValue = data.NewValue;
        if (newValue < Cutoff)
            _bubbleTransform.localScale = Vector3.zero;
        else 
            _bubbleTransform.localScale = newValue * SliderToScaleMultiplier * _initialScale;
        PlayerInfoSystem.Instance.UpdateBubbleRadius(_bubbleTransform.localScale.x);
    }
}
