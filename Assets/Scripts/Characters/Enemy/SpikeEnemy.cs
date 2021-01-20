using UnityEngine;

public class SpikeEnemy : Enemy
{
    [SerializeField] private Direction spikeDirection;
    public Direction GetSpikeDirection { get => spikeDirection; }

}
