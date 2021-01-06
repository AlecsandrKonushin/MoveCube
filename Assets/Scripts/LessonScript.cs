using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonScript : MonoBehaviour
{
    [SerializeField]
    GameObject activateObject;

    public void ActivateObject(float time)
    {
        StartCoroutine(CoActivateObject(time));
    }

    private IEnumerator CoActivateObject(float time)
    {
        yield return new WaitForSeconds(time);
        activateObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            activateObject.SetActive(false);
        }
    }
}
