﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if (attacker) { return; }
               
    }
}
