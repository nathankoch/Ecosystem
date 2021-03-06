﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAnim : MonoBehaviour
{

    QuestAIStateMachine machine;
    Animator anim;
    SpriteRenderer sr;

    IAstarAI ai;
    // Use this for initialization
    void Start()
    {
        machine = GetComponent<QuestAIStateMachine>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        ai = GetComponent<IAstarAI>();
        InvokeRepeating("UpdateFacing", 0.0f, 0.51f);
    }

    void UpdateFacing()
    {
        if (machine.CurrentState == QuestAIStateMachine.State.Idle)
        {
            anim.enabled = false;
        }
        else
        {
            anim.enabled = true;
            if (transform.position.x > ai.steeringTarget.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }
}
