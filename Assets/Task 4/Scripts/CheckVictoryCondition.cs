using System.Collections.Generic;
using UnityEngine;

public class CheckVictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;

    private IVictoryCondition _victoryCondition;
    private List<Transform> _ballsOnScene = new List<Transform>();
    public void SetCondition(IVictoryCondition condition)
    {
        _victoryCondition = condition;
    }

    private void OnEnable()
    {
        BallSpawner.BallSpawned += AddBallInList;
        GeneralBall.BallBurst += DeleteBallFromList;
        GeneralBall.BallBurst += CheckVictory;
        BallSpawner.BallSpawnStopped += CheckVictory;
    }

    private void OnDisable()
    {
        BallSpawner.BallSpawned -= AddBallInList;
        GeneralBall.BallBurst -= DeleteBallFromList;
        GeneralBall.BallBurst -= CheckVictory;
        BallSpawner.BallSpawnStopped -= CheckVictory;
    }

    public void CheckVictory()
    {
        CheckWinCondition();
    }
    public void CheckVictory(Transform obj)
    {
        CheckLooseCondition(obj);
        CheckWinCondition();
    }

    private void AddBallInList(Transform obj)
    {
        _ballsOnScene.Add(obj);
    }
    private void DeleteBallFromList(Transform obj)
    {
        _ballsOnScene.Remove(obj);
    }
    
    private void CheckWinCondition()
    {
        if (_victoryCondition.CheckWinCondition(_ballsOnScene))
        {
            Debug.Log("Вы выиграли!");
            Cursor.lockState = CursorLockMode.Locked;
            SetPanelIsActive(_winPanel);
        }
    }
    private void CheckLooseCondition(Transform obj)
    {
        if (_victoryCondition.CheckLooseCondition(obj))
        {
            Debug.Log("Вы проиграли");
            Cursor.lockState = CursorLockMode.Locked;
            SetPanelIsActive(_loosePanel);
        }
    }

    private void SetPanelIsActive(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
