using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 newPos;
    [SerializeField]
    private float speed;

    private Vector3 firstPos;
    [SerializeField]
    private float posXTwo;
    [SerializeField]
    private float posYTwo;

    private bool moveToFirstPos = false;

    public bool canMove = true;

    public bool someMove;
    [SerializeField]
    private Transform[] allPosition;
    private int countPos;

    private void Awake()
    {
        firstPos = transform.position;

        newPos = transform.position;
        newPos.x = posXTwo;
        newPos.y = posYTwo;

        countPos = 0; 
    }

    private void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        if (canMove)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, newPos, speed * Time.deltaTime);

            if (someMove)
            {
                if (myTransform.position == newPos)
                {
                    newPos = allPosition[countPos].position;

                    if (countPos < allPosition.Length - 1)
                        countPos++;
                    else
                        countPos = 0;


                }
            }
            else
            {
                if (myTransform.position == newPos)
                {
                    if (moveToFirstPos)
                    {
                        newPos.x = posXTwo;
                        newPos.y = posYTwo;
                        moveToFirstPos = false;
                    }
                    else
                    {
                        newPos = firstPos;
                        moveToFirstPos = true;
                    }
                }
            }
        }
    }
}
