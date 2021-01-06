using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;

    [SerializeField]
    private Player player;

    [SerializeField]
    SpriteRenderer spriteRen;

    private List<Vector3> touchPositions = new List<Vector3>();

    public bool canSwipe = false;


    // Данные на квест при первом свайпе
    // 
    // Есть ли такой квест
    [SerializeField] private bool questFirstSwipe;
    // Квест включения коллайдера
    [SerializeField] private bool collActive;
    // Объект на котором активируется коллайдер
    [SerializeField] private GameObject objectColl;

    // Был ли первый свайп
    private bool firstSwipe;

    void Start()
    {
        dragDistance = 2;
    }

    private void Update()
    {
        if (!canSwipe || player.CanMove)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            fp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
            {
                if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                {
                    if ((lp.x > fp.x))
                    {   // Свайп вправо
                        if (player.canMoveRight)
                            player.SetDirectionPlayer("right");
                    }
                    else
                    {   // Свайп влево
                        if (player.canMoveleft)
                            player.SetDirectionPlayer("left");
                    }
                }
                else
                {   
                    if (lp.y > fp.y)  
                    {   // Свайп вверх
                        if (player.canMoveup)
                            player.SetDirectionPlayer("up");
                    }
                    else
                    {   // Свайп вниз
                        if (player.canMovedown)
                            player.SetDirectionPlayer("down");
                    }
                }
            }

            if(questFirstSwipe || !firstSwipe)
            {
                if (collActive)
                {
                    StartCoroutine(ActiveColliderObject());
                }
            }
        }
    }

    private IEnumerator ActiveColliderObject()
    {
        yield return new WaitForSeconds(.5f);

        objectColl.GetComponent<BoxCollider2D>().enabled = true;
    }
}
