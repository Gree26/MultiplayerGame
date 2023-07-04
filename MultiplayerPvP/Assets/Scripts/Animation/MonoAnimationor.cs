using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class MonoAnimationor : MonoBehaviour
{
    protected List<Sprite> currentAnimation = new List<Sprite>();

    protected readonly float defaultAnimationDelay = 0.1f;

    protected int currentFrame = 0;

    protected float animationSpeed = 0.1f;

    protected SpriteRenderer myRenderer;

    public List<Sprite> CurrentAnimation
    {
        get
        {
            return currentAnimation;
        }
    }

    private void OnEnable()
    {
        if(!this.TryGetComponent<SpriteRenderer>(out myRenderer))
        {
            Debug.LogError("Sprite Renderer Component does not exist on this game object!");
            Destroy(this);
        }

        if (currentAnimation.Count==0)
        {
            currentAnimation.Add(myRenderer.sprite);
        }
    }

    /// <summary>
    /// Set and play the given animation with the default animation delay
    /// </summary>
    /// <param name="animationStrip"></param>
    public void NewAnimation(List<Sprite> animationStrip, bool reset) => NewAnimation(animationStrip, defaultAnimationDelay, reset);

    /// <summary>
    /// Stop the current animation and set the current sprite to the given sprite.
    /// </summary>
    /// <param name="newSprite"></param>
    public void SetSprite(Sprite newSprite, bool reset) => NewAnimation(new List<Sprite>(){newSprite}, reset);

    /// <summary>
    /// Set and play the given animation with the given animation delay
    /// </summary>
    /// <param name="animationStrip">Set of sprites that make up hte animation.</param>
    /// <param name="animationDelay">Animation Delay</param>
    public void NewAnimation(List<Sprite> animationStrip, float animationDelay, bool reset)
    {
        if (animationStrip == null || animationStrip.Count == 0 || animationStrip.Contains(null))
        {
            this.enabled = false;
            return;
        }

        if (!reset)
        {
            NewAnimationNoReset(animationStrip, animationDelay);
            return;
        }

        this.enabled = true;

        animationSpeed = animationDelay;
        currentFrame = 0;
        SetAnimationList(animationStrip);
    }

    private void NewAnimationNoReset(List<Sprite> animationStrip, float animationDelay)
    {
        if (animationStrip == null || animationStrip.Count == 0 || animationStrip.Contains(null))
        {
            this.enabled = false;
            return;
        }
        this.enabled = true;

        animationSpeed = animationDelay;
        if (currentFrame >= animationStrip.Count)
        {
            currentFrame = 0;
        }
        SetAnimationList(animationStrip);
    }

    /// <summary>
    /// So that a new list is avtually created rather than a reference when
    /// passing that list to this class. 
    /// </summary>
    /// <param name="animationStrip"></param>
    private void SetAnimationList(List<Sprite> animationStrip)
    {
        currentAnimation.Clear();

        foreach(Sprite spr in animationStrip)
        {
            currentAnimation.Add(spr);
        }
    }

    public abstract void NextFrame();
    public abstract bool SinglePlayNextFrame();
}
