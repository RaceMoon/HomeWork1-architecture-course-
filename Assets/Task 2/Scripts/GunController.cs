using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GeneralGun[] _guns;
    [SerializeField] private Material _selectedGunMaterial;
    [SerializeField] private Material _defaultGunMaterial;

    private GeneralGun _activeGun;

    private int _indexOfCurrentGun;

    private void Start()
    {
        _indexOfCurrentGun = 0;
        _activeGun = _guns?[_indexOfCurrentGun];
        ChangeColor(_selectedGunMaterial);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeCurrentGun(--_indexOfCurrentGun);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeCurrentGun(++_indexOfCurrentGun);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _activeGun.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _activeGun.Reloading();
        }
    }

    private void ChangeCurrentGun(int indexOfNextGun)
    {
        if (indexOfNextGun > _guns.Length - 1)
        {
            indexOfNextGun = 0;
        }
        else if (indexOfNextGun < 0)
        {
            indexOfNextGun = _guns.Length - 1;
        } 

        ChangeColor(_defaultGunMaterial);
        _indexOfCurrentGun = indexOfNextGun;
        _activeGun = _guns[_indexOfCurrentGun];
        ChangeColor(_selectedGunMaterial);
    }

    private void ChangeColor(Material material)
    {
        foreach (MeshRenderer meshRender in _activeGun.GetComponentsInChildren<MeshRenderer>())
        {
            meshRender.material = material;
        }
    }
}
