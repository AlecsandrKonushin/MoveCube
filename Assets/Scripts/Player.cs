using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ColorController
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRen;

    private Vector3 newPos;
    private float speed = 3;
    private bool canMove = false;

    [SerializeField]
    private Sprite[] mySprites;

    [SerializeField]
    GameObject restartLVImage;

    [SerializeField] private GameObject[] myColliders;

    private MoveObject objectTouch;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

            if (transform.position == newPos)
                canMove = false;
        }
    }

    public void SetDirection(SwipeDirection direction)
    {
        switch (direction)
        {
            case SwipeDirection.Up:
                myColliders[0].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
                break;
            case SwipeDirection.Right:
                myColliders[1].SetActive(true);
                newPos = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
                break;
            case SwipeDirection.Down:
                myColliders[2].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
                break;
            case SwipeDirection.Left:
                myColliders[3].SetActive(true);
                newPos = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
                break;
        }

        canMove = true;
    }

    // Столкновение с каким-либо объектом.
    public void CollisionWithObjext(GameObject collision)
    {
        if (collision.transform.tag == "wall")
        {
            ContactWall(collision);
        }
        else if (collision.transform.tag == "coinGold")
        {
            ContactCoin(collision);
        }
        else if (collision.transform.tag == "colorChange")
        {
            ColorController colorObj = collision.GetComponent<ColorController>();

            ChangeMyColor(colorObj);
        }
        else if (collision.transform.tag == "stop")
        {
            newPos.x = collision.transform.position.x;
            newPos.y = collision.transform.position.y;

            //SideMoveTrue();

            DeEnableMyColliders();
        }
        else if (collision.transform.tag == "quest")
        {
            string butArrow = collision.GetComponent<ButtonQuest>().MyArrow;

            if (butArrow != null)
            {
                //if (butArrow == sideNow)
                //    ContactQuest(collision);
                //else
                //    return;
            }
            else
                ContactQuest(collision);
        }
    }

    // Контакт со стеной.
    private void ContactWall(GameObject collision)
    {
        Wall wall = collision.gameObject.GetComponent<Wall>();

        // Если стена - портал.
        if (wall.IsPortal)
        {
            //if (sideNow == wall.sideIn)
            //{
            //    ContactWallPortal(wall);

            //    return;
            //}
        }
        // Если стена двигается.
        if (wall.IMove)
        {
            if (wall.MyColor != MyColor)
            {
                MoveObject moveObj = collision.gameObject.GetComponent<MoveObject>();
                moveObj.canMove = false;
                objectTouch = moveObj;

                DeEnableMyColliders();
            }
        }
        // Если стена - граница, то рестарт уровня.
        if (wall.MyColor == AllColor.white)
        {
            DeEnableMyColliders();

            //soundCon.PlaySound("restart");
            StartCoroutine(RestartLevel());
        }
        // Если цвет Player не равен цвету стены, то он останавливается рядом с ней.
        if (MyColor != wall.MyColor)
        {
            //if (!canMoveleft)
            //    newPos.x = wall.transform.position.x + 2;
            //else if (!canMoveRight)
            //    newPos.x = wall.transform.position.x - 2;
            //else if (!canMoveup)
            //    newPos.y = wall.transform.position.y - 2;
            //else if (!canMovedown)
            //    newPos.y = wall.transform.position.y + 2;

            // Отключаются колайдеры Player.
            DeEnableMyColliders();
        }
    }

    // Контакт со стеной порталом.
    // Player доходит до стены.
    private void ContactWallPortal(Wall wall)
    {
        //if (sideNow == wall.sideIn)
        //{
        //    DeEnableMyColliders();

        //    soundCon.PlaySound("portal");

        //    Vector3 exitPos = wall.ExitPortal.transform.position;

        //    if (wall.sideOut == "right")
        //    {
        //        myTransform.position = new Vector3(exitPos.x + 2, exitPos.y);
        //        SetDirectionPlayer("right");
        //    }
        //    else if (wall.sideOut == "left")
        //    {
        //        myTransform.position = new Vector3(exitPos.x - 2, exitPos.y);
        //        SetDirectionPlayer("left");
        //    }
        //    else if (wall.sideOut == "up")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y + 2);
        //        SetDirectionPlayer("up");
        //    }
        //    else if (wall.sideOut == "down")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y - 2);
        //        SetDirectionPlayer("down");
        //    }

        //    return;
        //}
    }

    // Контакт с коином.
    // Player становится на позицию коина, 
    // запускается следующий уровень через mainCon.
    private void ContactCoin(GameObject collision)
    {
        newPos.x = collision.transform.position.x;
        newPos.y = collision.transform.position.y;

        //soundCon.PlaySound("coin");

        //swipeCon.canSwipe = false;

        DeEnableMyColliders();

        Destroy(collision.gameObject);
        //StartCoroutine(mainCon.NextLevel());
    }

    // Контакт с квестом.
    // Позиция Player рядом с кнопкой квеста.
    // Отключение колайдеров и запуск квеста.
    private void ContactQuest(GameObject collision)
    {
        newPos.x = collision.transform.position.x;
        newPos.y = collision.transform.position.y;

        //if (!canMoveleft)
        //    newPos.x = collision.transform.position.x + 1.3f;
        //else if (!canMoveRight)
        //    newPos.x = collision.transform.position.x - 1.3f;
        //else if (!canMoveup)
        //    newPos.y = collision.transform.position.y - 1.3f;
        //else if (!canMovedown)
        //    newPos.y = collision.transform.position.y + 1.3f;

        DeEnableMyColliders();

        collision.GetComponent<ButtonQuest>().ActivateQuest();
        collision.GetComponent<ButtonQuest>().enabled = false;
    }

    // Изменение цвета Player при контакте с красителем
    private void ChangeMyColor(ColorController colorObj)
    {
        if (colorObj.MyColor != MyColor)
        {
            //soundCon.PlaySound("change");

            MyColor = colorObj.MyColor;

            if (MyColor == AllColor.green)
                spriteRen.sprite = mySprites[0];
            else if (MyColor == AllColor.yellow)
                spriteRen.sprite = mySprites[1];
            else if (MyColor == AllColor.blue)
                spriteRen.sprite = mySprites[2];
            else if (MyColor == AllColor.red)
                spriteRen.sprite = mySprites[3];

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void DeEnableMyColliders()
    {
        for (int i = 0; i < myColliders.Length; i++)
        {
            myColliders[i].SetActive(false);
        }
    }

    private IEnumerator RestartLevel()
    {
        restartLVImage.SetActive(true);
        yield return new WaitForSeconds(.15f);
        restartLVImage.SetActive(false);

        yield return new WaitForSeconds(.1f);

        //mainCon.RestartLevel();
    }

    public void PauseApp(bool pause)
    {
        if (pause)
        {
            canMove = false;
            //swipeCon.canSwipe = false;
        }
        else
        {
            canMove = true;
            //swipeCon.canSwipe = true;
        }
    }
}
