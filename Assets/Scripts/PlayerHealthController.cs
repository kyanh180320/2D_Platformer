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
    private SpriteRenderer theSR;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
        else
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
        }
    }
    public void DealDamge()
    {
        print(invincibleCounter);

        if (invincibleCounter <= 0) // bat tu trong 1s
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            else // state invincible
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
            }
            UIController.instance.UpdateHealthDisplay();
        }


    }

}
