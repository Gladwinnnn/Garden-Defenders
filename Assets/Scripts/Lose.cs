using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<HealthDisplay>().loseHealth();
    }
}
