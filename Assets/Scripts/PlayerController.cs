using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    // Variables pour le déplacement
    public float moveSpeed;
    public float jumpForce;
    public float gravity;

    
    //vecteur Direction souhaitée
    Vector3 moveDir;

    private Animator anim;
    bool isWalking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {   
        // calcul de la direction
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed); // calcule la direction du mouvement

        // check de la touche Espace
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            //On saute
            moveDir.y = jumpForce;
        }

       

        // On applique la gravité
        moveDir.y -= gravity * Time.deltaTime;

        
        // Si on se déplace (si mouvement !=0)
        if (moveDir.x !=0 || moveDir.z !=0)
        {
            // Le personnage marche
            isWalking = true;

            // On tourne le personnage dans la bonne dir
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3 (moveDir.x,0,moveDir.z)),0.15f);
        }

        

        else
        {
            // le personnage s'arette
            isWalking = false;
        }

        anim.SetBool("IsWalking", isWalking);

        // On applique le déplacement
        cc.Move(moveDir * Time.deltaTime);

    }
}
