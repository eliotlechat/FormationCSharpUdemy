using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject CoinEffect;
    public GameObject SnailEffect;
    public int nbCoins = 0;
    private bool canInstantiate = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            GameObject go =Instantiate(CoinEffect, other.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            nbCoins++;
            Destroy(other.gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)

    // si on utilise le character controller il faut utiliser la fonction onControllerColliderHit
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // si le monstre me touche
        if(collision.gameObject.tag == "Snail")
        {
            // je suis touché
            print("Aïe !");
        }

        // si je saute sur la carapace
        if(collision.gameObject.tag == "Shell"&& canInstantiate)
        {
            canInstantiate = false;
            print("touché !");
            GameObject go = Instantiate(SnailEffect, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.6f);
            // le parent de la carapace (c'est à dire le snail) se détruit
            Destroy(collision.gameObject.transform.parent.gameObject,0.5f);
            StartCoroutine("resetInstantiate");
        }
        
    }
    // On réinitianalise canInstantiate après 0.8s

    IEnumerator resetInstantiate()
    {
        yield return new WaitForSeconds(0.8f);
        canInstantiate = true;
    }
}
