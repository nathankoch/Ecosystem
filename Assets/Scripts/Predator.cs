﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : MonoBehaviour
{

    private AIStateMachine machine;

    private GameObject hungryIcon;


    void Start()
    {
        machine = GetComponent<AIStateMachine>();
    }

    void Update()
    {
        if (machine.currentState != AIStateMachine.State.Seek)
        {
            // hungryIcon.SetActive(false);
            return;
        }
        else
        {
            // hungryIcon.SetActive(true);
            // hungryIcon.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
