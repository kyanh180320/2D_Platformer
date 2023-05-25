using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;
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

    }
    public void DealDamge()
    {
        currentHealth--;
        UIController.instance.UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
