using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] protected AllColor myColor;

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
        pink,
        red
    }
}
