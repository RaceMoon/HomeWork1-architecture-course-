using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isBadBoy { get; private set; }
    public bool isGoToWar { get; private set; }

    private void Start()
    {
        
    }
    public void SetBadBoy()
    {
        isBadBoy = true;
    }

    public void SetGoToWar()
    {
        isGoToWar = true;
    }
}
