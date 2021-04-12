using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int health = 10;

    public void GiveDamage()
    {
        health -= 10;
    }
}
