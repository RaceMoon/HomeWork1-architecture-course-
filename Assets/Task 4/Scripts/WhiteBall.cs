using UnityEngine;

public class WhiteBall : GeneralBall
{
    protected override Material SetMaterial()
    {
        return Resources.Load("White", typeof(Material)) as Material;
    }
}
