using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfoSystem : PersistentSingleton<PlayerInfoSystem>
{
    public float BubbleRadius { get; private set; }

    public void UpdateBubbleRadius(float newRadius)
    {
        BubbleRadius = newRadius;
    }
}
