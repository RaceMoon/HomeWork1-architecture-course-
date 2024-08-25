using UnityEngine;

public class RedBall : GeneralBall
{
    protected override Material SetMaterial()
    {
        return Resources.Load("Red", typeof(Material)) as Material;
    }
}
