using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(speed, 0, 0);   
    }
}
