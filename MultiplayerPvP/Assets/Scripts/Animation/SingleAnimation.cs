using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays through an Animation once and then stops.
/// </summary>
public class SingleAnimation : MonoAnimationor
{
    public override void NextFrame()
    {
        if (currentFrame >= currentAnimation.Count)
        {
            return;
        }
        myRenderer.sprite = currentAnimation[currentFrame];
        currentFrame++;
        
    }

    public override bool SinglePlayNextFrame()
    {
        throw new System.NotImplementedException();
    }
}
