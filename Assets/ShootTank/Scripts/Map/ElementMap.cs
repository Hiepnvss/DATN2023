using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeElement
{
    Brick,
    Stone,
    Grass,
    Water,
    LaneSpeed,
    Wall
}
namespace ShootTank.Map
{
    public class ElementMap : MonoBehaviour
    {
        public TypeElement typeElement;
    }
}