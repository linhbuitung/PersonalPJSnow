using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float torqueAmount = 1f;
    private Rigidbody2D body;
    private SurfaceEffector2D effector;
    [SerializeField]
    private float baseSpeed = 15f;
    [SerializeField]
    private float boostSpeed = 25f;
    public bool isActive = true;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        effector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDisable();
        
    }


    void CheckDisable()
    {
        if(isActive == true)
        {
            Rotate();
            Boost();
        } else
        {
            effector.speed = 0;
        }
    }
    void Boost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            effector.speed = boostSpeed;
        } else
        {
            effector.speed = baseSpeed;
        }
    }
    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            body.AddTorque(torqueAmount * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D))
        {
            body.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }
}
