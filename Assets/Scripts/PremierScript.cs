using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremierScript : MonoBehaviour
{

    public Rigidbody rb;
    public Renderer rend;




    // Start is called before the first frame update
    void Start()
    {
        rend.material.color = Color.blue;
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


}