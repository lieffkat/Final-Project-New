using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public CoinManager MyCoinManager;
    public Text CoinCountText;

    // Update is called once per frame
    void Update()
    {
        if(MyCoinManager != null && CoinCountText != null) {
            CoinCountText.text = "SCORE: " + MyCoinManager.GetCoinCount().ToString("0000");

        }
    }
}
