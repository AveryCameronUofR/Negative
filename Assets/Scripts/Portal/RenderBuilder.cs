using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBuilder : MonoBehaviour
{
    void OnEnable()
    {
        var cam = GetComponent<Camera>();
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }
}
