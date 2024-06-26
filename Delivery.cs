using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 PackageColor = new Color32(0, 255, 255, 255);
    [SerializeField] Color32 DeliveryColor = new Color32(255, 0, 0, 255);
    [SerializeField] float DeleteSpeed = 0.05f;
    public bool packageDelivered = true;
    SpriteRenderer spriteRenderer;
    public int counterDelivered = 0;
    public GameObject deathCamera;


    [SerializeField] Text PacketsAmount, PacketsLeftAmount, Turbo;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = PackageColor;
        deathCamera.SetActive(false);
        SetStats();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger");
        //if the thing we trigger was the package print added up
        if (other.tag == "Package" && packageDelivered == true)
        {
            Debug.Log("Package added up");
            Destroy(other.gameObject, DeleteSpeed);
            packageDelivered = false;
            spriteRenderer.color = DeliveryColor;

        }
        if (other.tag == "Delivery" && packageDelivered == false)
        {
            Debug.Log("Package delivered");
            counterDelivered = counterDelivered + 1;
            packageDelivered = true;
            spriteRenderer.color = PackageColor;
            SetStats();
            if (counterDelivered >= 5)
            {
                gameOver();
            }
        }
    }

    void SetStats()
    {
        PacketsAmount.text = counterDelivered.ToString();
        PacketsLeftAmount.text = (5 - counterDelivered).ToString();


    }
    void gameOver()
    {
        Driver driver = GetComponent<Driver>();
        driver.StopTimer();
        
        deathCamera.SetActive(true);
    }

}

/*
                if (counterDelivered =< 8)
            {
                gameOver();
            }*/
