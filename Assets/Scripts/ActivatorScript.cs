using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorScript : MonoBehaviour
{
    [SerializeField]
    private ActivationScript objectActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            objectActivate.ActivateMe();
            Debug.Log("dfdfdf");
        }
    }

}
