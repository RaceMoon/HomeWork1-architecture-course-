using System.Collections.Generic;
using UnityEngine;

public class SellerController : MonoBehaviour
{
    private Queue<ISeller> _sellerBehaviours;

    private void OnEnable()
    {
        Seller.CharacterReadyTrade += SetTradeQueue;
    }

    private void OnDisable()
    {
        Seller.CharacterReadyTrade -= SetTradeQueue;
    }
    private void SetTradeQueue(Seller seller, bool isBadBoy, bool isGoToWar)
    {
        _sellerBehaviours = new Queue<ISeller>();

        if (isBadBoy == false)
        {
            _sellerBehaviours.Enqueue(new TradeFruits());

            if (isGoToWar)
            {
                _sellerBehaviours.Enqueue(new TradeArmor());
            }
        }
        else
        {
            _sellerBehaviours.Enqueue(new NoTrade());
        }

        seller.SetBehaviour(_sellerBehaviours);
    }
}
