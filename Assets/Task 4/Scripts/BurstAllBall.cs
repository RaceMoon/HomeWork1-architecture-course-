using System.Collections.Generic;
using UnityEngine;

public class BurstAllBall : IVictoryCondition
{
    public bool CheckLooseCondition(Transform obj)
    {
        return false;
    }

    public bool CheckWinCondition(List<Transform> ballsInScene)
    {
        if (BallSpawner.IsWork == false)
            if (ballsInScene.Count == 0)
                return true;
            else return false;
        else return false;
    }
}
