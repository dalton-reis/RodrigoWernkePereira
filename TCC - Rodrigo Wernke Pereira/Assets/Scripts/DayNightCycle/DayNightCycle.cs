﻿using System;
using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public float DayLengthInSeconds;

    public GameObject DayTimeGameObject;

    private float _rotationAngle = 0;

    private double _rotationPercentage = 0;

    private int day = 0;

    private void Update() {

        float angle = transform.eulerAngles.z;

        transform.Rotate(0, 0, DegreeInSeconds(DayLengthInSeconds) * Time.deltaTime);

        _rotationAngle += DegreeInSeconds(DayLengthInSeconds) * Time.deltaTime;

        _rotationPercentage = ((_rotationAngle / 360) * -1);
        
        if (_rotationAngle < -360) {
            _rotationAngle = 0;
            day++;
        }

        TimeOfTheDay();
    }

    private double ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, double value) {
        double scale = (newEnd - newStart) / (originalEnd - originalStart);
        return (newStart + ((value - originalStart) * scale));
    }

    private void TimeOfTheDay() {

        double decimalTime = ConvertRange(0, 1, 0, 24, _rotationPercentage);

        int hour = (int)(decimalTime);
               
        int min = (int)((decimalTime - Math.Truncate(decimalTime)) * 60);

        //Debug.Log("Day: " + day + ". " + hour + ":" + min);

        DayTimeGameObject.GetComponent<TextMeshProUGUI>().text = "Day: " + day + ". " + hour + ":" + min;
    }

    private float DegreeInSeconds(float seconds) {
        return -360 / seconds;
    }
}