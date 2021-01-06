using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardButtonQuest : ButtonQuest
{

    [SerializeField] private bool activeNow = false;
    
    [SerializeField] protected HardButtonQuest oppositeButton;

    [SerializeField] private Sprite deactiveSprite;
    
    public override void ActivateQuest()
    {
        if (activeNow)
            return;
        else
        {            
            activeNow = true;
            oppositeButton.DeactiveButton();            
        }

        base.ActivateQuest();
    }

    public void DeactiveButton()
    {
        activeNow = false;

        GetComponentInChildren<SpriteRenderer>().sprite = deactiveSprite;
    }
}
