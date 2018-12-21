﻿/*
The MIT License (MIT)

Copyright (c) 2018 Twan Veldhuis, Ivar Troost

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using System.Collections;

public enum WaterState { Ebb, Flood }
public class WaterScript : MonoBehaviour
{
    public WaterState State { get { return state; } set { state = value; } }
    [SerializeField]
    WaterState state = WaterState.Ebb;

    Rigidbody2D rbody = null;

    [SerializeField]
    Transform floodHeight = null, ebbHeight = null;

    [SerializeField]
    float speed = 1, delay = 0;

    [SerializeField]
    Transform mobilePart;

    float startTime;

    // To set the delay from a Level script
    public void SetProperties(float delay)
    {
        this.delay = delay;
    }

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    public void SetStartTime(float time)
    {
        startTime = time;
    }

	// Update is called once per frame
	void Update () {
        float fx = 0.8f, fy = 1.4f;
        float sx = -0.01f, sy = 0.005f;
        mobilePart.localPosition = new Vector3(sx * Mathf.Cos(fx * (Time.time - startTime)), 0.005f + sy * Mathf.Sin(fy * (Time.time - startTime)), 0);
    }

    void FixedUpdate()
    {
        if (Time.time > startTime + delay)
        {
            float targetHeight = state == WaterState.Ebb ? ebbHeight.position.y : floodHeight.position.y;
            float speedMod = Mathf.Clamp(targetHeight - rbody.position.y, -1, 1);
            rbody.velocity = new Vector2(0, speedMod * speed);
        }
    }
}
