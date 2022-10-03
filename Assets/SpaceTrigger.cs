using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            LaunchPlanetAnimation();
        }
    }

    private void LaunchPlanetAnimation()
    {
        animator.SetTrigger("launch");
    }
}
