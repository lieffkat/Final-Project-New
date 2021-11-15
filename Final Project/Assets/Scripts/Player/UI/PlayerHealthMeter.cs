using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This presents the player with the current heart count as reported by the PlayerHealth script.  
/// </summary>
public class PlayerHealthMeter : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    public PlayerHealth myPlayerHealth;

    private void LateUpdate()
    {
        RefreshHealthView();
    }

    public void RefreshHealthView()
    {
        if (myPlayerHealth != null)
        {
            float currHealth = myPlayerHealth.GetHealthPercentage();
            heart1.color = (currHealth >= 0.33f) ? Color.white : Color.black;
            heart2.color = (currHealth >= 0.66f)? Color.white : Color.black;
            heart3.color = (currHealth >= 0.99f) ? Color.white : Color.black;
        }
    }
}
