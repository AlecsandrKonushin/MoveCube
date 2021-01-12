﻿using UnityEngine;

public class PlayerContacts : MonoBehaviour
{
    private Player player;
    private GameObject collisionObject;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void CollisionWithObjext(GameObject collision)
    {
        collisionObject = collision;

        if (collision.transform.tag == "block")
            ContactWithBlock();
        else if (collision.transform.tag == "wall")
            ContactWithWall();
        else if (collision.transform.tag == "door")
            ContactWithDoor();
        else if (collision.transform.tag == "colorChange")
            ContactWithChangeColor();
        else if (collision.transform.tag == "portal")
            ContactWithPortal();
    }

    private void ContactWithBlock()
    {
        Block block = collisionObject.GetComponent<Block>();

        if (player.MyColor != block.MyColor)
        {
            player.SetNewPosition(block.transform.position);

            player.DeEnableMyColliders();
        }
    }

    private void ContactWithDoor()
    {
        Door door = collisionObject.GetComponent<Door>();

        player.SetNewPosition(door.transform.position, false);

        if (door.ExitDoor)
        {
            player.AfterMove += ContactWithExit;
        }
    }

    private void ContactWithExit()
    {
        player.AfterMove -= ContactWithExit;

        MainController.Instance.PlayerWinLevel();
    }

    private void ContactWithWall()
    {
        MainController.Instance.PlayerDeath();
    }

    private void ContactWithChangeColor()
    {
        ColorObject colorObj = collisionObject.GetComponent<ColorObject>();

        if (colorObj.MyColor != player.MyColor)
        {
            player.SetNewColor(colorObj.MyColor);            

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void ContactWithPortal()
    {

    }

    private void ContactWallPortal(Block wall)
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
}