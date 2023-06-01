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

        if (invincibleCounter <= 0) // trang thai khong bat tu
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            }
            else // state invincible , invincibleCounter > 0 change color
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                PlayerController.instance.KnockBack();
            }
            UIController.instance.UpdateHealthDisplay();
        }


    }

}
