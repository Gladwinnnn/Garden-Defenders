using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";


    void Start()
    {
        CreateDefenderParent();
    }

    void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    void OnMouseDown()
    {
        AttemptToPlaceDefenderAct(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    void AttemptToPlaceDefenderAct(Vector2 gridPosition)
    {   
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnerDefender(gridPosition);
            StarDisplay.SpendStars(defenderCost);
        }
        else
        {
            Debug.Log("Not Enough Stars!");
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    Vector2 SnapToGrid(Vector2 raWorldPosition)
    {
        float newX = Mathf.RoundToInt(raWorldPosition.x);
        float newY = Mathf.RoundToInt(raWorldPosition.y);
        return new Vector2(newX, newY);
    }

    void SpawnerDefender(Vector2 roundedPosition)
    {
        Defender newDefender = Instantiate(defender, roundedPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
