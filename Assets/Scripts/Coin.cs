using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ActivationScript
{
    [SerializeField]
    public bool invisible;

    private SpriteRenderer spriteren;

    private void Start()
    {
        spriteren = GetComponent<SpriteRenderer>();
    }

    private void ActivateSprite()
    {
        spriteren.enabled = true;
    }

    public override void ActivateMe()
    {
        ActivateSprite();
    }

}
