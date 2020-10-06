using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour

{
    private CharacterController cc;
    public float moveSpeed;
    public float jumpForce;
    private Vector3 moveDir;
    public float gravity;
    private Animator anim;
    public bool isWalking = false;

    private void Start()
    {



        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

       


    }

    private void Update()
    {

        // informer d'une anim booléenne

        anim.SetBool("IsWalking", isWalking);

        // calcul de la direction selon les touches du clavier et il faut appliquer un speed


        moveDir = new Vector3(Input.GetAxis("Horizontal")*moveSpeed , moveDir.y, Input.GetAxis("Vertical")*moveSpeed );
        print(moveDir);

        // on applique le déplacement
        cc.Move(moveDir*Time.deltaTime);

        // on applique la gravité

        moveDir.y -= gravity*Time.deltaTime;

        // On saute si on appuie sur la touche espace est que le player est au sol

        if (Input.GetButtonDown("Jump")&&cc.isGrounded)
        {
            moveDir.y = jumpForce;
        }

        // le personnage applique une rotation selon la direction des fleches.

        if (moveDir.x !=0 || moveDir.z != 0)
        {
            isWalking = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.15f);
        }
        else
        {
            isWalking = false;
        }


        



    }


}































/*
     
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



     */
