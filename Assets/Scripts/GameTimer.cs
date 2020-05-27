using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in Seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinish = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinish)
        {
            FindObjectOfType<LevelController>().LeveltimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
