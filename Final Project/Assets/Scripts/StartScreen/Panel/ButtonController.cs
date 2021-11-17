using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public float clickPercentage = 0f;
    public float clickTime = 0.5f;
    bool _isHovered = false;
    Button myButton;
    public Image fillTimerImg;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    //update hover value
    public virtual void SetHover(bool isHovered)
    {
        _isHovered = isHovered;
    }

    public virtual void DoClick()
    {
        clickPercentage = 0f;
        if (myButton) myButton.onClick.Invoke();
    }

    private void Update()
    {
        //if I'm currently being hovered...
        if (_isHovered)
        {
            clickPercentage += Time.deltaTime;
            //... then if i've been hovered long enough...
            if (clickPercentage > clickTime)
            {
                //... then trigger click behavior
                DoClick();
            }
        }
        else
        {
            clickPercentage -= Time.deltaTime;
        }
        clickPercentage = Mathf.Clamp(clickPercentage, 0f, clickTime);
        fillTimerImg.fillAmount = clickPercentage / clickTime;
    }
}
