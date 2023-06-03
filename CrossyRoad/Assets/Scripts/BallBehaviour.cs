using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed;
    public bool direction = false;
    public bool turning = false;
    Transform turnpos;
    Vector3 stride;
    public int cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Turn"))
        {           
            turnpos = collision.gameObject.transform;
            if (cooldown <= 0)
            {
                turning = true;
                cooldown = 120;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown--;
        if (turning)
        {
            if (this.transform.position.x >= turnpos.position.x && this.transform.position.z >= turnpos.position.z)
            {
                direction = !direction;
                turning = false;
            }
        }

        if (direction)
        {
            stride.Set(speed, 0, 0);
        }
        else
        {
            stride.Set(0, 0, speed);
        }     
        transform.Translate(stride);
    }
}
