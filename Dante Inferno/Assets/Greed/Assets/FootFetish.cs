using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootFetish : MonoBehaviour
{
    public AudioSource walky, runny;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {

            if(Input.GetKey(KeyCode.LeftShift)){
                walky.enabled = false;
                runny.enabled = true;
            }

            else {

                walky.enabled = true;
                runny.enabled = false;
            }
        }

            else {
                walky.enabled = false;
                runny.enabled = false;
            }

    }
}



