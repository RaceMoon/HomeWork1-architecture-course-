using System.Collections.Generic;
using UnityEngine;

public class BurstColorBall : IVictoryCondition
{
    private List<Transform> _ballsOnScene;
    private GeneralBall _typeOfBall;

    public BurstColorBall(GeneralBall ball)
    {
        _typeOfBall = ball;
    }  

    public bool CheckWinCondition(List<Transform> ballsOnScene)
    {
        if (BallSpawner.IsWork == false)
        {
            foreach (Transform transform in ballsOnScene)
            {
                if (transform.GetComponent<GeneralBall>().GetType() == _typeOfBall.GetType())
                {
                    Debug.Log (transform.GetComponent<GeneralBall>().GetType());
                    Debug.Log(_typeOfBall.GetType());
                    return false;
                } 
            }
            return true;
        } 
        return false;
    }

    public bool CheckLooseCondition(Transform obj)
    {
        if (obj.GetComponent<GeneralBall>().GetType() != _typeOfBall.GetType()) 
        {
            return true;
        } 
        return false;
    }
}
