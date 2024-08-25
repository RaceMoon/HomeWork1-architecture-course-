using System.Collections.Generic;
using UnityEngine;

public interface IVictoryCondition
{
    public bool CheckWinCondition(List<Transform> ballsInScene);
    public bool CheckLooseCondition(Transform obj);
}
