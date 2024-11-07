using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody Vel;
    [SerializeField] public static float speed = 3f;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource killSound;
    void Start()
    {
        Vel = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float HorIn = Input.GetAxis("Horizontal");
        float VerIn = Input.GetAxis("Vertical");
        
        Vel.velocity = new Vector3(HorIn * speed,Vel.velocity.y, Vel.velocity.z );
    }
}
