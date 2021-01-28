using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private TypeEnemy type;
    public TypeEnemy Type { get => type; }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}

public enum TypeEnemy
{
    Spike
}
