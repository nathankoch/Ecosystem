﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveWeeper : MonoBehaviour
{

    public float radius;

    IAstarAI ai;
    AIStateMachine machine;
    ScanForCoins scan;


    private void Start()
    {
        ai = GetComponent<IAstarAI>();
        machine = GetComponent<AIStateMachine>();
        scan = GetComponent<ScanForCoins>();

        ai.destination = GetRandomPoint();
    }

    private void Update()
    {
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
        {
            print("End of path");
            if (machine.currentState == AIStateMachine.State.Wander) {
                ai.destination = GetRandomPoint();     
            } else if (machine.currentState == AIStateMachine.State.Seek) {
                ai.destination = Seek();
            }
            ai.SearchPath();
        }
    }

    private Vector2 Seek()
    {
        return scan.closestCoinLocation;
    }

    private Vector2 GetRandomPoint()
    {
        var point = Random.insideUnitCircle * radius;
        point += transform.position.AsVector2();
        return point;
    }
}
