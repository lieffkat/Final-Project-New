using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    int CoinCount = 0;

    public void CollectCoin(int Amount) { CoinCount = CoinCount + Amount; }

    public int GetCoinCount() { return CoinCount; }
}
