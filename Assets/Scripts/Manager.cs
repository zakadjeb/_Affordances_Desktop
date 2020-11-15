﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.XR;
using System;
using LSL;


public class Manager : MonoBehaviour
{
    [Header("Timer and status")]
    public string CurrentStatus;
    public string LightStatus;
    public float DarkTimer = 0f;
    public float LightTimer = 0f;
    public bool isDark;
    public bool shownImperative;

    [Header("Managing trials")]
    public int TotalNumberTrials = 240;
    public int CurrentTrial = 0;
    public bool trialDone = false;
    public string CurrentDoorType;
    public string GoNoGoState;
    public List<string> GoNoGoList;
    public List<int> DoorCaseList;

    // [Header("Setting GameObjects")]
    // public GameObject SlidingDoor;
    // public GameObject SlidingDoor;


    [Header("Game settings")]
    public int TimeInDark = 5;
    public int DarkSD = 2;
    public List<int> TimeInDarkList;
    public int TimeToImperative = 4;
    public int LightSD = 2;
    public List<int> TimeToImperativeList;
    public GameObject Sphere;

    // Start is called before the first frame update
    void Start()
    {
        //Generating pseudo-randomized trial list
        for (int i = 0; i < (TotalNumberTrials / 3); i++)
        {
            DoorCaseList.Add(1);
            DoorCaseList.Add(2);
            DoorCaseList.Add(3);
            DoorCaseList = DoorCaseList.OrderBy(x => UnityEngine.Random.value).ToList();
        }

        //Generating pseudo-randomized GoNoGo list
        for (int i = 0; i < (TotalNumberTrials / 3); i++)
        {
            GoNoGoList.Add("Go");
            GoNoGoList.Add("NoGo");
            GoNoGoList = GoNoGoList.OrderBy(x => UnityEngine.Random.value).ToList();
        }

        //Generating randomized list of time in dark
        System.Random rnd = new System.Random();
        for (int i = 0; i < TotalNumberTrials; i++)
        {
            TimeInDarkList.Add(rnd.Next(TimeInDark-DarkSD, TimeInDark+DarkSD));
        }

        //Generating randomized list of time in dark
        for (int i = 0; i < TotalNumberTrials; i++)
        {
            TimeToImperativeList.Add(rnd.Next(TimeToImperative-LightSD, TimeToImperative+LightSD));
        }

        //Removing the cursor in-game
        Cursor.visible = false;

        //Setting start status
        isDark = true;
        DarkTimer = TimeInDarkList[CurrentTrial];
        LightTimer = TimeToImperativeList[CurrentTrial];
        GoNoGoState = "";
    }

    // Update is called once per frame
    void Update()
    {

        //Setting current status
        if (DoorCaseList[CurrentTrial] == 1) {CurrentDoorType = "Narrow";}
        if (DoorCaseList[CurrentTrial] == 2) {CurrentDoorType = "Mid";}
        if (DoorCaseList[CurrentTrial] == 3) {CurrentDoorType = "Wide";}
        if (isDark == false) {LightStatus = "LightsOn";}
        if (isDark == true) {LightStatus = "Dark";}
        CurrentStatus = "#" + CurrentTrial.ToString() + ";" + CurrentDoorType + ";" + LightStatus + ";" + GoNoGoState;

        //Countdown for dark
        if (DarkTimer >= 0 && isDark && !trialDone) {
            DarkTimer -= Time.deltaTime;
        }

        //Changes because it's now Light
        if (DarkTimer <= 0) {
            isDark = false;
            Sphere.SetActive(false);
        }

        //Countdown for imperative
        if (LightTimer >= 0 && !isDark && !trialDone) {
            LightTimer -= Time.deltaTime;
        }

        //Changes because of imperative stimulus
        if (LightTimer <= 0) {
            GoNoGoState = GoNoGoList[CurrentTrial];
            shownImperative = true;
        }

        //Once the trial is done
        if (trialDone && LightTimer <= 0 && DarkTimer <= 0){
            CurrentTrial += 1;
            DarkTimer = TimeInDarkList[CurrentTrial];
            LightTimer = TimeToImperativeList[CurrentTrial];
            isDark = true;
            trialDone =  false;
        }
    }

}
