using UnityEngine;

public class GreenBall : GeneralBall
{
    protected override Material SetMaterial()
    {
        return Resources.Load("Green", typeof(Material)) as Material;
    }
}
