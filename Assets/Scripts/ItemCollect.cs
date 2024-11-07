using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    int points = 0;
    [SerializeField] UnityEngine.UI.Text pointsText;
    [SerializeField] AudioSource coinSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            Destroy(other.gameObject);
            points++;
            pointsText.text = "Points: " + points;

        }
    }
}
