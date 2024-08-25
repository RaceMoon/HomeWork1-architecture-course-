using UnityEngine;

public class GunTriple : GeneralGun
{
    private Transform[] _firePoints;

    public override void Fire()
    {
        foreach (Transform firePoint in _firePoints)
        {
            base.Fire(firePoint);
        }
    }

    protected override void GetFirePoint()
    {
        FirePoint[] firepoints = GetComponentsInChildren<FirePoint>();
        _firePoints = new Transform[firepoints.Length];
        int _currentPoint = 0;
        foreach (FirePoint firePoint in firepoints)
        {
            _firePoints[_currentPoint] = firePoint.GetComponent<Transform>();
            _currentPoint++;
        }
    }
}
