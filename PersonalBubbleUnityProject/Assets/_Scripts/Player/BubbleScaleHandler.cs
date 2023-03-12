using Microsoft.MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScaleHandler : MonoBehaviour
{
    [SerializeField] private PlayerInfo Player;
    [Range(0f, 1f)] [SerializeField] private float Cutoff = 0.1f;
    [SerializeField] private float SliderToScaleMultiplier = 2f;

    private Transform _bubbleTransform;
    private Vector3 _initialScale;

    private void Awake()
    {
        _bubbleTransform = gameObject.transform;
        _initialScale = _bubbleTransform.localScale;
    }

    public void OnSliderValueUpdated(SliderEventData data)
    {
        float newValue = data.NewValue;
        if (newValue < Cutoff)
            _bubbleTransform.localScale = Vector3.zero;
        else 
            _bubbleTransform.localScale = newValue * SliderToScaleMultiplier * _initialScale;

        Player.UpdateBubbleScale(_bubbleTransform.localScale);
    }
}
