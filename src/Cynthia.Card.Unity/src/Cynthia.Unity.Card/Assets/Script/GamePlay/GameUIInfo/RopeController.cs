﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class RopeController : MonoBehaviour
{
    public Slider rope;
    public Text TimeCount;
    public GameObject WolfIcon;
    private float ropeTime = 20f;
    private float endWaitTime = 0.5f;
    private int shakeRange = 1;
    public bool isRunning = false;
    public float remainingTime = 120f;
    public void StartRopeTimer(float totalTime = 120f)
    {
        rope.gameObject.SetActive(false); // is not active until ropeTime
        remainingTime = totalTime;
        isRunning = true;
    }
    public void StopRopeTimer()
    {
        rope.gameObject.SetActive(false);
        remainingTime = 0;
        isRunning = false;
    }
    private void FixedUpdate()
    {
        if (!isRunning)
        {
            return;
        }
        remainingTime -= Time.deltaTime;
        if (remainingTime < ropeTime + endWaitTime)
        {
            // active rope
            if (!rope.gameObject.activeSelf)
            {
                rope.maxValue = remainingTime - endWaitTime;
                rope.gameObject.SetActive(true);
            }
            rope.value = remainingTime - endWaitTime;
            TimeCount.text = ((int)(rope.value + 0.5)).ToString(); // add 0.5 to round
        }
        if (remainingTime <= 0)
        {
            StopRopeTimer();
        }
    }
    void Update()
    {
        WolfIcon.transform.eulerAngles = new Vector3(0, 0, Random.Range(-shakeRange, shakeRange));
    }
}
