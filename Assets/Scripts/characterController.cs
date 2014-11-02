﻿using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    //velocidad maxima de movimiento horizontal
    public float maxHorizontalSpeed = 10f;
    //fuerza de salto
    public float jumpMultiplier = 100f;
    //solo de prueba 1
    //public Transform groundCheck;
    //public float checkRadius = 0.2f;
    //public LayerMask trampolineLayer;
    //fin prueba 1
    //determina si debe o no saltar
    private bool canJump = false;
    //control de gordura por el cual rompe el trampoline
    public float gordura = 100f;
    private float consumo = 0f;
    private float jumpForce = 1f;
    private barController barra;
	// Use this for initialization
	void Start () {
        barra = GetComponentInChildren<barController>();
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    // Called every same time. Not need to use Time.deltatime
    void FixedUpdate() {
        //movimiento horizontal del caracter
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * maxHorizontalSpeed, rigidbody2D.velocity.y);

        //jumping
        //canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, trampolineLayer);
        //si puede saltar, se aplica una fuerza hacia arriba 
        if(gordura <=0f)
        {
            Debug.Log("sin calorias para saltar");
            return;
        }
        if (canJump)
        {
            //Debug.Log("salto");
            gordura -= consumo;
            rigidbody2D.AddForce(transform.up * jumpMultiplier * jumpForce);
            canJump = false;
            barra.setValue(gordura);
        }
        




        /*
         * prueba 1:
        if (!ground && rigidbody2D.velocity.y == 0) {
            ground = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.AddForce(transform.up * jumpMultiplier);
            ground = false;
        }
        */

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "candy")
        {
            Debug.Log("caramelo");
            energia energy = obj.gameObject.GetComponent<energia>();
            gordura += energy.calorias;
            Destroy(obj.transform.gameObject);
            barra.setValue(gordura);
        } 
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        //codigo cavernicola mejorar si la idea queda
        //deteccion de salto
        if (obj.gameObject.tag == "trampoline")
        {
            status stat = obj.gameObject.GetComponentInParent<status>();
            //if (stat == null)
            //    return;
            //Debug.Log("toco trampolin");
            //si toca un trampoline se revisa la gordura
                if (gordura > 100f || stat.jumps==0)
                {
                    //Debug.Log("rompio el piso");
                    //si el objeto excede el limite de gordura o el trampolin no tiene mas saltos se elimina el trampoline
                    Destroy(obj.transform.root.gameObject);
                }
                else
                {
                    //Debug.Log("salto");
                    //si no excede el limite, se setea que puede saltar
                    stat.jumps -= 1;
                    consumo = stat.consumo;
                    jumpForce = stat.jumpPower;
                    canJump = true;
                }
            
        }
        else if(obj.gameObject.tag == "fragil")
        {
            //si colisiona con un trampoline fragil se elimina el trampoline
            Destroy(obj.transform.root.gameObject);
        }
        /*else if (obj.gameObject.tag == "candy")
        {
            Debug.Log("caramelo");
            energia energy = obj.gameObject.GetComponent<energia>();
            gordura += energy.calorias;
            Destroy(obj.transform.root.gameObject);
        }*/
    }
}