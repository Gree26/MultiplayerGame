using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketInteractable : MonoBehaviour
{
    private bool _isThePlayerInRange = false;

    public void InRange(bool isThePlayerInRange)
    {
        Debug.Log((_isThePlayerInRange)? "Entered Range":"Left Range");
        _isThePlayerInRange = isThePlayerInRange;
    }

    private void OnGUI()
    {
        if (!_isThePlayerInRange) return;

        Rect labelRect = new Rect(0, 0, 20, 20);

        GUI.Label(labelRect, "X");
    }
}
