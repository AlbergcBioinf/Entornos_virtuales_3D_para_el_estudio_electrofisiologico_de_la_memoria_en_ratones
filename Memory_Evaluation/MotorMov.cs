using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorMov : MonoBehaviour
{
    public MoveCharacter moveCharacter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveCharacter.EnviarComando("1");           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveCharacter.EnviarComando("0");
        }
    }
}
