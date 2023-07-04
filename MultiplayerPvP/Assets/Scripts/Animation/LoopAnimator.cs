using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repeates the given animation until a new animation is given.
/// </summary>
internal class LoopAnimator : MonoAnimationor
{
    public override void NextFrame()
    {
        if (myRenderer == null)
            return;
        currentFrame++;
        if (currentFrame >= currentAnimation.Count)
        {
            currentFrame = 0;
        }
        myRenderer.sprite = currentAnimation[currentFrame];
    }

    /// <summary>
    /// Plays through the given animation once. 
    /// </summary>
    /// <returns>If the animation has been completed. </returns>
    public override bool SinglePlayNextFrame()
    {
        if (currentFrame >= currentAnimation.Count)
        {
            return true;
        }
        myRenderer.sprite = currentAnimation[currentFrame];
        currentFrame++;

        return false;
    }
}
