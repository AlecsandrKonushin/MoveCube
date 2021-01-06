using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    private AllColor myColor;
    public AllColor MyColor
    {
        get { return myColor; }
        set
        {
            myColor = value;
        }
    }

    public enum AllColor
    {
        green,
        yellow,
        blue,
        red,
        white
    }
}
