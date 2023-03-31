using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoSystem : PersistentSingleton<PlayerInfoSystem>
{
    public float BubbleRadius { get; private set; } = 10f;
    public bool BubbleVisibility { get; private set; } = true;

    public void UpdateBubbleRadius(float newRadius)
    {
        BubbleRadius = newRadius;
    }

    public void UpdateBubbleVisibility(bool newVisibility)
    {
        BubbleVisibility = newVisibility;
    }
}
