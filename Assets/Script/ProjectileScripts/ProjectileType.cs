using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileType : MonoBehaviour
{
    abstract public void OnHit(ContactPoint2D hit);
}
