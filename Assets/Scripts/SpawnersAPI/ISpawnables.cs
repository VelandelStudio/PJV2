using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnables
{
    int MaxSpawn { get; }
    float CalculTimeToNextSpawn();
    void SpawnMob();
}
