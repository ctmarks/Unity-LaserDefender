using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {
    public Transform hoursHand;
    public Transform minutesHand;
    public Transform secondsHand;

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;



    private void Update() {
        DateTime time = DateTime.Now;
        hoursHand.localRotation = 
            Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        minutesHand.localRotation = 
            Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        secondsHand.localRotation = 
            Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
}
