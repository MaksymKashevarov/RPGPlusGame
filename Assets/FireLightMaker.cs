using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLightMaker : MonoBehaviour
{
    public Light fireLight;
    public float fireSpeed = 0.1f;
    public float startIntensity = 3.0f;
    public float endIntensity = 1.3f;
    private bool isKeyLight;
    private bool isActivated;
    private float savedIntensity;
    private void Start()
    {
        fireLight = GetComponent<Light>();
        isActivated = true;
        isKeyLight = false;
        savedIntensity = fireLight.intensity;

    }

    private void Update()
    {

    }
}


