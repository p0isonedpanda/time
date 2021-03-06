﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance { get; private set; }
    CameraController cc;

    public Material backdrop;

    Camera camera;

    // Initialise singleton, throw error if there's more than one instance
    void Awake()
    {
        if (instance != null)
            throw new System.Exception();

        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        camera = Camera.main;
        cc = CameraController.instance;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Lerp time scale down and adjust fixedDeltaTime to allow for physics to continue making 50 checks a second
        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.05f, 0.2f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void SetTimeScale (float val)
    {
        Time.timeScale = val;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
