using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : ColorController
{
    public bool IMove = false;

    public bool IsPortal;

    public GameObject ExitPortal;
    public string sideIn;
    public string sideOut;

    [SerializeField] private SpriteRenderer spriteRen;
    public SpriteRenderer SpriteRen { get { return spriteRen; } }
}
