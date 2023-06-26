using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1_Animation : MonoBehaviour
{
    public Animator TheDoor;

    private void OnTriggerEnter(Collider other)
    {
        TheDoor.Play("FirstDoorUp");
    }

    private void OnTriggerExit(Collider other)
    {
        TheDoor.Play("FirstDoorDown");
    }

}