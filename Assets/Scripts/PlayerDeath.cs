using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] AudioSource deathFallSound;
    [SerializeField] public UnityEngine.UI.Text LifesText;
    [SerializeField] AudioSource deathKillSound;
    [SerializeField] UnityEngine.UI.Text gameover;
    [SerializeField] int SpeedDuration = 3;
    [SerializeField] private int DurabilityDuration = 3;
    private bool dead = false;
    [SerializeField] public int Lifes = 3;
    [SerializeField] public float SpeeedBonusAmount = 2f;
    public float speedMod = PlayerControl.speed;
    private bool Immortality = true;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            deathFallSound.Play();
            Die();
        }
        if (Lifes == 0)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerControl>().enabled = false;
            deathKillSound.Play();
            Die();
            gameover.text = "GAME OVER";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stena") && Immortality) // отнять жизнь за столкновение со стеной
        {
            Lifes--;
            LifesText.text = "Lifes: " + Lifes;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Body") && Immortality) // отнять жизнь за столкновение с машиной
        {
            Lifes--;
            LifesText.text = "Lifes: " + Lifes;
            Destroy(GameObject.FindGameObjectWithTag("Enemy Body"));
        }
        if (other.gameObject.CompareTag("Life Bonus")) // дать жизнь за бонус
        {
            if (Lifes < 3)
            { 
                Lifes++; 
            }
            LifesText.text = "Lifes: " + Lifes;
            Destroy(GameObject.FindGameObjectWithTag("Life Bonus"));
        }
        if (other.gameObject.CompareTag("DurabilityBonus")) // дать прочность за бонус
        {
            
            Destroy(GameObject.FindGameObjectWithTag("DurabilityBonus"));
            StartCoroutine(DurabilityBuff());
        }
        if (other.gameObject.CompareTag("SpeedBonus")) // дать скорость за бонус
        {
            Destroy(GameObject.FindGameObjectWithTag("SpeedBonus"));
            StartCoroutine(SpeedBuff());
        }
    }
    

    void Die()
    {
        dead = true;
        Invoke(nameof(ReloadLife),3.3f);
    }

    void ReloadLife()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpeedBuff()
    {
        ActivateSpeedBonus();
        yield return new WaitForSeconds(SpeedDuration);
        DeactivateSpeedBonus();
    }
    void ActivateSpeedBonus()
    {
        PlayerControl.speed += SpeeedBonusAmount;
    }
    void DeactivateSpeedBonus()
    {
        PlayerControl.speed = speedMod;
    }

    IEnumerator DurabilityBuff()
    {
        ActivateDurabilityBonus();
        yield return new WaitForSeconds(DurabilityDuration);
        DeactivateDurabilityBonus();
    }
    void ActivateDurabilityBonus()
    {
        Immortality = false;
    }
    void DeactivateDurabilityBonus()
    {
        Immortality = true;
    }
    
}
