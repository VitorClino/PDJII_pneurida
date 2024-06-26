using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int lifeMAX = 5;
    private int life;
    public int Life { get { return life; } }
    private float speed = 15;
    private Rigidbody rb;

    private float maxDir = 22f, maxEsq = -22f;

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
            float move = Input.acceleration.x * Time.deltaTime * speed;
            Vector3 newPosition = transform.position + new Vector3(move,0,0);

            newPosition.x = Mathf.Clamp(newPosition.x, maxEsq, maxDir);

            transform.position = newPosition;
            //rb.velocity = new Vector3(Input.acceleration.x * speed, 0f, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("life = " + life);
        if(life <= 0)
        {
            GameManager.Instance.Derrota();
        }
        UIConfig.Instance.AtualizaVidaUI();
    }

    public void Cure(int cure)
    {
        if (life < lifeMAX)
            life += cure;
        UIConfig.Instance.RecuperaVida();
        Debug.Log("life = " + life);
    }
}
