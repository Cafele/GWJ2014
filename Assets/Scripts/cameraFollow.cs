using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
    
    //transform que se busca seguir
    public Transform target;
    //vector3 a la cual la camara tratara de moverse
    private Vector3 targetPos;
    //velocidad de movimiento
    public float followSpeed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //se utiliza la posicion actual de la camara y solo se modifica el componente en y
        targetPos = transform.position;
        targetPos.y = target.position.y;
        //movemos la camara hacia ese lugar solo en y
        transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        //se puede usar algo como el movimiento del pathfollow pero deberia mejorar con un smooth de camera
	}
}
