using UnityEngine;

public class SpikeEnemy : Enemy
{
    [SerializeField] private Direction dangerDirectionMove;
    public Direction GetDangerDirectionMove { get => dangerDirectionMove; }

}
