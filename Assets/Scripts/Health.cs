using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    
    public void Damage(int vida)
    {
        health -= vida;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
