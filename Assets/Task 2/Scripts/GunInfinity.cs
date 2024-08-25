public class GunInfinity : GeneralGun
{
    public override void Fire()
    {
        ++_currentCountBullet;
        base.Fire();
    }
}
