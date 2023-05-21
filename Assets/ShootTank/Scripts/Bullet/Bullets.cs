using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBullet
{
    Normal,
    Power
}
namespace ShootTank.Tank
{
    public class Bullets : EntityManager
    {
        public TypeBullet typeBullet;

    }
}