using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int currentHealth = 1;

    public void Damage(int damageAmount)

    {

        //subtract damage amount when Damage function is called

        currentHealth -= damageAmount;

        //Check if health has fallen below zero

        if (currentHealth <= 0)

        {

            //if health has fallen below zero, deactivate it 

            gameObject.SetActive(false);

        }

    }

}
