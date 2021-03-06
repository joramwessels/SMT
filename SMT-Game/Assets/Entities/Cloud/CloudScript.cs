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

public class CloudScript : MonoBehaviour {

    GameObject lightning;

    Transform leftBound;
    Transform rightBound;

    [SerializeField]
    // The event exists of: startWaitTime, thunderTime, waitTime, thunderTime, endWaitTime
    float size = 5, startWaitTime = 1, waitTime = 1, thunderTime = 3, endWaitTime = 1;

    float spawn_time;

    public void SetProperties(float? size, float? waitTime, float? thunderTime, float? startWaitTime, float? endWaitTime)
    {
        if (size.HasValue)
            this.size = size.Value;
        if (waitTime.HasValue)
            this.waitTime = waitTime.Value;
        if (thunderTime.HasValue)
            this.thunderTime = thunderTime.Value;
        if (startWaitTime.HasValue)
            this.startWaitTime = startWaitTime.Value;
        if (endWaitTime.HasValue)
            this.endWaitTime = endWaitTime.Value;
    }

    // Use this for initialization
    void Start ()
    {
        leftBound = GameObject.Find("LeftBounds").transform;
        rightBound = GameObject.Find("RightBounds").transform;
        lightning = transform.GetChild(0).gameObject;
        spawn_time = Time.time;
    }

    void OnEnable()
    {
        Start();
    }

    void OnDisable()
    {
        StopAllCoroutines();
        if (gameObject.GetComponent<Rigidbody2D>() != null)
            Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null) {
            if ((gameObject.transform.position.x < leftBound.transform.position.x && gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                || (gameObject.transform.position.x > rightBound.transform.position.x && gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)) {
                gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(2 * gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            }
        }

        // Termination
        if (Time.fixedTime >= spawn_time + startWaitTime + waitTime + 2 * thunderTime + endWaitTime)
        {
            this.OnDisable();
            ObjectPool.Despawn(gameObject, "cloud pool");
        }
        // End wait
        else if (Time.fixedTime >= spawn_time + startWaitTime + waitTime + 2 * thunderTime)
        {
            lightning.SetActive(false);
        }
        // 2nd thunder
        else if (Time.fixedTime >= spawn_time + startWaitTime + waitTime + thunderTime)
        {
            lightning.SetActive(true);
        }
        // 2nd wait
        else if (Time.fixedTime >= spawn_time + startWaitTime + thunderTime)
        {
            lightning.SetActive(false);
        }
        // 1st thunder
        else if (Time.fixedTime >= spawn_time + startWaitTime)
        {
            lightning.SetActive(true);
        }
        // 1st wait
        else
        {
            lightning.SetActive(false);
        }
    }
}
