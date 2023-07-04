using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _followTransform;

    [SerializeField]
    [Min(0)]
    private float _followSpeed = 0.075f;

    private void Awake()
    {
        NewPosition(_followTransform.transform.position);
    }

    private void LateUpdate()
    {
        //Not happy with doing this. Probably a better alternative
        if (this.transform.position!=_followTransform.position)
        {
            BeginFollow();
        }
    }

    /// <summary>
    /// Begin moving towards the new position.
    /// </summary>
    private void BeginFollow()
    {
        float distanceBetweenPoints = Vector2.Distance((Vector2)this.transform.position, (Vector2)_followTransform.position);
        if (distanceBetweenPoints >= 0.001f)
        {
            Vector2 _directionVector = ((Vector2)_followTransform.position - (Vector2)this.transform.position).normalized;
            Vector2 newPosition = (Vector2)this.transform.position + (_directionVector * _followSpeed * distanceBetweenPoints);
            NewPosition(newPosition);
        }
        else
        {
            
            Vector2 newPosition = _followTransform.transform.position;
            NewPosition(newPosition);
        }
    }

    /*
     private IEnumerator BeginFollow()
    {
        following = true;
        while ((Vector2)this.transform.position != (Vector2)_followTransform.transform.position)
        {
            yield return new WaitForFixedUpdate();
            float distanceBetweenPoints = Vector2.Distance((Vector2)this.transform.position, (Vector2)_followTransform.transform.position);
            if (distanceBetweenPoints <= _followSpeed)
            {
                Vector2 newPosition = _followTransform.transform.position;
                NewPosition(newPosition);
            }
            else
            {
                Vector2 _directionVector = ((Vector2)_followTransform.transform.position - (Vector2)this.transform.position).normalized;
                Vector2 newPosition = (Vector2)this.transform.position + (_directionVector * _followSpeed);
                NewPosition(newPosition);
            }
        }
        following = false;
    }*/

    /// <summary>
    /// Convert a Vector2 position to a vector3 that will not affect the Z position.
    /// </summary>
    /// <param name="newPos">New Position value.</param>
    private void NewPosition(Vector2 newPos)
    {
        this.transform.position = new Vector3(newPos.x,newPos.y,this.transform.position.z);
    }
}
