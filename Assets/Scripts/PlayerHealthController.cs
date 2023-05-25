using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;
    public float invincibleLength;
    private float invincibleCounter;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }
    public void DealDamge()
    {
        if(invincibleCounter <= 0) // bat tu trong 1s
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                invincibleCounter = invincibleLength;
            }
            UIController.instance.UpdateHealthDisplay();
        }
        

    }

}
