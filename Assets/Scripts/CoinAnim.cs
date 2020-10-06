using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnim : MonoBehaviour
{

    public Vector3 dir;

    private void Update()
    {
        transform.Rotate(dir * Time.deltaTime);
    }

}

