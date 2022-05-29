using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLogger : MonoBehaviour
{
    public void OnHover()
    {
        Debug.Log("Hover");
    }

    public void OnGrab()
    {
        Debug.Log("Grab");
    }
}
