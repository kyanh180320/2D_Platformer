using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isCollected;
    public bool isGem;
    public bool isHeal;
    public GameObject pickupEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemCount();
                isCollected = true;
                Destroy(gameObject);
                PickUpEffect();
            }
            if(isHeal)
            {
                PlayerHealthController.instance.HealPlayer();
                isCollected = true;
                Destroy(gameObject);
                PickUpEffect();

            }

        }
    }
    public void PickUpEffect()
    {
        Instantiate(pickupEffect,transform.position, Quaternion.identity);
    }
}
