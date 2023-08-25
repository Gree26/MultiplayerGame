using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DirectionAnimation
{
    public Sprite Idle { get; private set; }
    public List<Sprite> Move { get; private set; }
    public Sprite AttackStart { get; private set; }
    public Sprite AttackStop { get; private set; }
    public List<Sprite> AttackStartMove { get; private set; }
}
