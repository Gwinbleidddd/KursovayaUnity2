using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sticking : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

     void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.name == "Player")
         {
             collision.gameObject.transform.SetParent(null);
         }
     }
}
