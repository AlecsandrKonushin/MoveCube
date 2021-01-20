﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Персонаж. Умеет двигаться, имеет цвет.
/// </summary>
[RequireComponent(typeof(CharacterContacts))]
public class Character : ColorObject
{
    [SerializeField] protected float speed = 8;

    protected Animator animator;
    protected SpriteRenderer spriteRen;
    protected CharacterContacts contacts;

    protected bool fall = false;
    protected bool canMove = false;
    protected Vector3 newPos;

    protected Direction directionMove;
    public Direction GetDirectionMove { get => directionMove; }
    protected const float offsetBlock = 1f;
    protected const float offsetswipe = 20f;

    protected void Start()
    {
        spriteRen = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        contacts = GetComponent<CharacterContacts>();
    }

    protected void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

            if (transform.position == newPos)
            {
                EndMove();
            }
        }
    }

    protected virtual void EndMove()
    {
    }

    /// <summary>
    /// Задача следующей позиции в определённом направлении до края карты.
    /// </summary>
    /// <param name="direction"></param>
    public void SetNewPosition(Direction direction)
    {
        directionMove = direction;

        switch (direction)
        {
            case Direction.Up:
                contacts.EnableCollider(0);
                newPos = new Vector3(transform.position.x, transform.position.y + offsetswipe, transform.position.z);
                break;
            case Direction.Right:
                contacts.EnableCollider(1);
                newPos = new Vector3(transform.position.x + offsetswipe, transform.position.y, transform.position.z);
                break;
            case Direction.Down:
                contacts.EnableCollider(2);
                newPos = new Vector3(transform.position.x, transform.position.y - offsetswipe, transform.position.z);
                break;
            case Direction.Left:
                contacts.EnableCollider(3);
                newPos = new Vector3(transform.position.x - offsetswipe, transform.position.y, transform.position.z);
                break;
        }

        canMove = true;
    }

    /// <summary>
    /// Задача следующей позиции до препятсвия.
    /// </summary>
    /// <param name="objectPos">Препятствие</param>
    /// <param name="offset">Отступ до препятствия. По умолчанию отсутствует</param>
    public void SetNewPosition(Vector2 objectPos, bool offset = true)
    {
        Vector2 position = objectPos;

        if (offset)
        {
            if (directionMove == Direction.Up)
                position.y -= 1;
            else if (directionMove == Direction.Right)
                position.x -= 1;
            else if (directionMove == Direction.Down)
                position.y += 1;
            else if (directionMove == Direction.Left)
                position.x += 1;
        }

        newPos = position;
    }

    /// <summary>
    /// Установка следующей позиции до стены.
    /// Запуск корутины падения.
    /// </summary>
    /// <param name="wallPos"></param>
    public void SetPositionBeforeWall(Vector2 wallPos)
    {
        Vector2 position = transform.position;

        if (directionMove == Direction.Up)
            position.y = wallPos.y - 1;
        else if (directionMove == Direction.Right)
            position.x = wallPos.x - 1;
        else if (directionMove == Direction.Down)
            position.y = wallPos.y + 1;
        else if (directionMove == Direction.Left)
            position.x = wallPos.x + 1;

        newPos = position;
        fall = true;

        PlayAnimation(CharacterAnim.Fall);
    }

    public void PlayAnimation(CharacterAnim anim)
    {
        animator.SetTrigger(anim.ToString());
    }

    public virtual void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}

public enum CharacterAnim
{
    Fall
}