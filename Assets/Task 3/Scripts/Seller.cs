using System;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public static event Action<Seller, bool, bool> CharacterReadyTrade;
    private Queue<ISeller> _sellerBehaviours;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character component) == false)
            return;

        Character character = other.GetComponent<Character>();

        CharacterReadyTrade(this, character.isBadBoy, character.isGoToWar);

        foreach (ISeller behaviour in _sellerBehaviours)
        {
            behaviour.Trade();
        }
    }

    public void SetBehaviour(Queue<ISeller> behaviour)
    {
        _sellerBehaviours = behaviour;
    }
}
