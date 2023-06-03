using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTiles : MonoBehaviour
{
    public GameObject Tile_bridge, Trap_door, Trap_spike, Trap_swing , Trap_fire, Tile_turn;
    public float x = 0;
    public float z = 0;
    int total = 0;
    int row = 0;
    float dirf = 0;
    bool last = false;
    bool turn = false;
    bool direction = false;
    int cooldown = 0;
    Vector3 vec;
    
    // Start is called before the first frame update
    void Start()
    {
       
        vec.Set(x, 1, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction) dirf = 1;
        else dirf = 0;
        if (cooldown == 0)
        {
            if (x > 15)
            {
                cooldown = 20;
            }
            // direction true = ++x
            last = direction;
            vec.Set(x, 1, z);

            if (row > (5 + Random.Range(1, 4)))
            {
                Instantiate(Tile_turn, vec+new Vector3(0f, -4.3f, 0f), Quaternion.Euler(0f, dirf * 90f, 0f));
                turn = true;
            }

            else if ((row) % 8 == Random.Range(3, 4))
            {
                if (x > 10 || z > 10)
                {
                    int trapRNG = Random.Range(1, 5);
                    if (trapRNG == 1)
                        Instantiate(Trap_door, vec, Quaternion.Euler(0f, dirf * 90f, 0f));
                       
                    else if (trapRNG == 2)
                        Instantiate(Trap_spike, vec, Quaternion.Euler(0f, dirf * 90f, 0f));
                       
                    else if (trapRNG == 3)
                    {
                        if (direction)
                        {
                            Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 00f, 0f));

                        }
                        else
                            Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 90f, 0f));
                        Instantiate(Trap_fire, new Vector3(x, 0.83f, z), Quaternion.Euler(0f, dirf * 90f, 0f));
                    }
                    else
                    {
                        if (direction)
                        {
                            Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 00f, 0f));

                        }
                        else
                            Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 90f, 0f));

                        Instantiate(Trap_swing, vec + new Vector3(0f, 8f, 0f), Quaternion.Euler(0f, dirf * 270f, 0f));
                    }
                }
                else
                {
                    if (direction)
                    {
                        Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 00f, 0f));

                    }
                    else
                        Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 90f, 0f));
                }

            }
           

            else
            {
                if (direction)
                {
                    Instantiate(Tile_bridge, vec, Quaternion.Euler(0f, 00f, 0f));
                  
                }
                else
                    Instantiate(Tile_bridge, vec, Quaternion.Euler(0f,90f, 0f));


            }

            if (x - z > 10)
            {
                direction = false;


            }

            else if (z - x > 10)
            {
                direction = true;

            }

            else if (turn)
            {
                direction = !direction;
                row = 0;
                turn = false;
            }

            if (direction)
            {
                x += 1;
            }

            else
            {
                z += 1;
            }

            if (last == direction)
                row++;

            else
            {
                row = 0;
                total++;

            }
        }
        else
        {
            cooldown--;
        }
    }
}
