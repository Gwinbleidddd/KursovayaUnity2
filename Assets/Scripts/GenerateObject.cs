using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text pointsText;
    int points = 0;
    Random rnd = new Random();
    private int height;
    public GameObject cubePrefab;
    public GameObject LifeBonusPrefab;
    public GameObject SpeedBonusPrefab;
    public GameObject DurabilityBonusPrefab;
    [SerializeField] float MaxSpeedGen = 0;
    [SerializeField] float DifficultyInk = 0;
    [SerializeField] float MaxDurabilityGen = 0;
    [SerializeField] float MaxCarGen = 0;
    [SerializeField] float MaxLifeGen = 0;
    [SerializeField] float CarCord = 0;
    void rHeight()
    {
        height = rnd.Next(2,8);
    }
    void peregon() // очки за избегания машин
    {
        if(GameObject.FindGameObjectWithTag("Enemy Body") != null) {
            if ((GameObject.FindGameObjectWithTag("Enemy Body").transform.position.z + 1) < (transform.position.z))
            {
                Destroy(GameObject.FindGameObjectWithTag("Enemy Body"));
                points++;
                pointsText.text = "Points: " + points;
            }
        }
        
    }
    void Update()
    {
        CarCord = -GameObject.FindGameObjectWithTag("Road").transform.position.z;
        if (CarCord - DifficultyInk > 300) // ускорение игры
        {
            RoadMoving.speed += 0.03f;
            DifficultyInk = CarCord;
        }
        if (CarCord - MaxCarGen > 20 && CarCord < 950) // генерация машин
        {
            rHeight();
            Instantiate(cubePrefab,new Vector3(height, -1, transform.position.z+50),Quaternion.identity,GameObject.FindGameObjectWithTag("Road").transform);
            rHeight();
            cubePrefab.tag = "Enemy Body";
            MaxCarGen = CarCord;
        }

        if (CarCord - MaxLifeGen > 200) // генерация бонусов жизни
        {
            Instantiate(LifeBonusPrefab,new Vector3(height, 0, transform.position.z+50),Quaternion.identity,GameObject.FindGameObjectWithTag("Road").transform);
            rHeight();
            LifeBonusPrefab.tag = "LifeBonus";
            MaxLifeGen = CarCord;
        }
        if (CarCord - MaxSpeedGen > 150) // генерация бонусов скорости
        {
            Instantiate(SpeedBonusPrefab,new Vector3(height, 0, transform.position.z+50),Quaternion.identity,GameObject.FindGameObjectWithTag("Road").transform);
            rHeight();
            SpeedBonusPrefab.tag = "SpeedBonus";
            MaxSpeedGen = CarCord;
        }
        if (CarCord - MaxDurabilityGen > 250) // генерация бонусов прочности
        {
            Instantiate(DurabilityBonusPrefab,new Vector3(height, 0, transform.position.z+50),Quaternion.identity,GameObject.FindGameObjectWithTag("Road").transform);
            rHeight();
            DurabilityBonusPrefab.tag = "DurabilityBonus";
            MaxDurabilityGen = CarCord;
        }
        peregon();
    }
}

