using UnityEngine;

public abstract class GeneralGun : MonoBehaviour
{
    protected int _currentCountBullet;

    [SerializeField] private int _maxBullet;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speedBullet;

    private Transform _firePoint;
    private void Awake()
    {
        GetFirePoint();
        _currentCountBullet = _maxBullet;
    }

    public virtual void Fire()
    {
        Fire(_firePoint);
    }

    public virtual void Fire(Transform firePoint)
    {
        if (GetBulletInfo())
        {
            Bullet bullet = Instantiate(_bulletPrefab, firePoint.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Inicialize(_speedBullet);
            _currentCountBullet--;
            Debug.Log("Выстрел! Патронов " + _currentCountBullet + "/" + _maxBullet);
        }
    }

    public void Reloading()
    {
        _currentCountBullet = _maxBullet;
        Debug.Log("Перезарядка");
    }
    protected virtual void GetFirePoint()
    {
        _firePoint = GetComponentInChildren<FirePoint>().GetComponent<Transform>();
    }

    private bool GetBulletInfo()
    {
        return GetBulletInfo(1);
    }

    private bool GetBulletInfo(int countBulletForFire)
    {
        if (_currentCountBullet - countBulletForFire < 0)
        {
            Debug.Log("Недостаточно патронов для выстрела");
            return false;
        }
        else
        {
            return true;
        }
    }
}
