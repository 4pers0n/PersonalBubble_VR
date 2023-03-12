using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores essential player information that will be synchronized across all players
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    private Vector3 _initialBubbleScale;
    private Vector3 _bubbleScale;

    private void Start()
    {
        GameObject bubbleVisual = GameObject.FindGameObjectWithTag("BubbleVisual");
        _initialBubbleScale = bubbleVisual.transform.localScale;
        _bubbleScale = _initialBubbleScale;
    }
    public void UpdateBubbleScale(Vector3 newScale)
    {
        _bubbleScale = newScale;
    }
}
