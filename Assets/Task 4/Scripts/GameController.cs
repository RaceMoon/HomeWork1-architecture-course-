using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CheckVictoryCondition _checkVictoryCondition;
    [SerializeField] private BallSpawner _ballSpawner;
    [SerializeField] private RedBall _redBall;
    [SerializeField] private GreenBall _greenBall;
    [SerializeField] private WhiteBall _whiteBall;

    private IVictoryCondition _condition;

    public void SetRedBall()
    {
        SetVictoryCondition(_redBall);
    }

    public void SetGreenBall()
    {
        SetVictoryCondition(_greenBall);
    }

    public void SetWhiteBall()
    {
        SetVictoryCondition(_whiteBall);
    }

    public void SetAllBall()
    {
        _condition = new BurstAllBall();
        StartGame(_condition);
    }

    private void SetVictoryCondition(GeneralBall ball)
    {
        _condition = new BurstColorBall(ball);
        StartGame(_condition);
    }

    private void StartGame(IVictoryCondition condition)
    {
        _checkVictoryCondition.SetCondition(condition);
        _ballSpawner.StartSpawn();
    }

}
