using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBodyType : MonoBehaviour
{
    [SerializeField]
    public DirectionAnimation North { get; private set; }
    [SerializeField]
    public DirectionAnimation East { get; private set; }
    [SerializeField]
    public DirectionAnimation South { get; private set; }
    [SerializeField]
    public DirectionAnimation West { get; private set; }
    
}
