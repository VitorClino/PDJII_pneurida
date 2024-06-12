using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int lifeMAX = 5;
    private int life;

    private float speed = 6;
    private Rigidbody rb;

    private static Player _instance = null;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player esta null");
            }
            return _instance;
        }
    }
    
    public void Awake()
    {
        _instance = this;
        life = lifeMAX;
        rb = GetComponent<Rigidbody>();
    }       

    public void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector3 acellerometer = Input.acceleration;

            Vector3 dir = new Vector3(acellerometer.x, 0f, 0f);
            dir.Normalize();

            rb.AddForce(dir * speed);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        GameManager.Instance.SpeedVariate(-0.4f);
        Debug.Log("life = " + life);
    }

    public void Cure(int cure)
    {
        if (life < lifeMAX)
            life += cure;
        Debug.Log("life = " + life);
    }
}
