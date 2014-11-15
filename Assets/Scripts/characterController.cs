using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
    public GameObject GUICamera;
    public Transform deathMenu;
    public Transform menu;
    private int jumps = 0;
    private int candy = 0;
    private float time = 0f;
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
    private bool paused = false;
	// Use this for initialization
	void Start () {
        Time.timeScale =1f;
        barra = GetComponentInChildren<barController>();
        jumps = 0;
        candy = 0;
        time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pause();
            //transform.root.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dead();
        }
	}

    // Called every same time. Not need to use Time.deltatime
    void FixedUpdate() {
        //movimiento horizontal del caracter
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * maxHorizontalSpeed, rigidbody2D.velocity.y);

        //jumping
        //canJump = Physics2D.OverlapCircle(groundCheck.position, checkRadius, trampolineLayer);
        //si puede saltar, se aplica una fuerza hacia arriba 
        if (gordura <= 0f)
        {
            Debug.Log("sin calorias para saltar");
            return;
        }
        if (canJump)
        {

            //Debug.Log("salto"+jumpMultiplier * jumpForce);
            gordura -= consumo;
            //rigidbody2D.AddForce(Vector3.zero);
            Vector2 a = rigidbody2D.velocity;
            a.y = 0f;
            rigidbody2D.velocity = a;

            rigidbody2D.AddForce(transform.up * jumpMultiplier * jumpForce);

            barra.setValue(gordura);
            canJump = false;
            jumps++;
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
        
        //codigo cavernicola mejorar si la idea queda
        //deteccion de salto
        //Debug.Log(obj.gameObject.tag);
        if (obj.gameObject.tag == "trampoline" && !canJump)
        {
            status stat = obj.gameObject.GetComponentInParent<status>();
            if (stat == null)
                return;
            //si toca un trampoline se revisa la gordura
            if (gordura > 100f || stat.jumps == 0)
            {
                //si el objeto excede el limite de gordura o el trampolin no tiene mas saltos se elimina el trampoline
                //Debug.Log("entro aca");
                //dead();
                Destroy(obj.transform.parent.gameObject);
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
        else if (obj.gameObject.tag == "candy")
        {
            candy++;
            Debug.Log("caramelo");
            energia energy = obj.gameObject.GetComponent<energia>();
            gordura += energy.calorias;
            barra.setValue(gordura);
            Destroy(obj.gameObject);
            Debug.Log("destruir: " + obj.gameObject.tag);
        }
        else if (obj.gameObject.tag == "enemy")
        {
            dead();
        }
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        
        
    }

    void dead()
    {
        menu.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        GUICamera.SetActive(true);
        Time.timeScale = 0f;
        deathMenu.FindChild("jumps Text").GetComponent<TextMesh>().text = "Jumps: "+jumps;
        deathMenu.FindChild("candy Text").GetComponent<TextMesh>().text = "Candy: " + candy;
        deathMenu.FindChild("time Text").GetComponent<TextMesh>().text = "Time: " + time.ToString("F2") + " seconds";
    }

    void pause()
    {
        Debug.Log("pause");
        menu.gameObject.SetActive(true);
        deathMenu.gameObject.SetActive(false);
        GUICamera.SetActive(true);
        Time.timeScale = 0f;
    }
}
