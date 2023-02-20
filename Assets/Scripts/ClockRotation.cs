using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockRotation : MonoBehaviour
{
    public GameObject secNeedle;
    public GameObject minNeedle;
    public GameObject hourNeedle;
    public string timeZoneId;

    private DateTime now;
    private TimeZoneInfo timeZone;
    private int hour;
    private int minute;
    private int sec;
    // Start is called before the first frame update
    void Start()
    {
        timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        setCurrTimeData();
        rotateNeedle();
    }

    // Update is called once per frame
    void Update()
    {
        setCurrTimeData();
        rotateNeedle();
    }

    public void setCurrTimeData()
    {
        now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        hour = now.Hour;
        minute = now.Minute;
        sec = now.Second;
    }

    public void rotateNeedle()
    {
        secNeedle.transform.localRotation = Quaternion.Euler(0, 0, -sec * 6);
        minNeedle.transform.localRotation = Quaternion.Euler(0, 0, -(float)(minute*6.0+sec*0.1));
        hourNeedle.transform.localRotation = Quaternion.Euler(0, 0, -(float)(hour*30+minute*0.5));
    }

}
