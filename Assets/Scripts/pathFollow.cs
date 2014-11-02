using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathFollow : MonoBehaviour {

    //enumerador de los tipos de movimiento posibles del PathFollow
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }
    //tipo de movimiento que se va a usar
    public FollowType Type = FollowType.MoveTowards;
    //path que se va a seguir
    public pathController Path;
    //velocidad con el que se va a mover
    public float speed = 1f;
    //cercania a uno de los puntos del path a partir del cual empezamos a buscar el siguiente
    public float maxDistanceToACheckPoint = 0.1f;
    //punto actual del path que estamos siguiendo
    private IEnumerator<Transform> currentPoint;

	// Use this for initialization
	void Start () {
        //si no hay path salimos
        if (Path == null)
            return;
        //obtenemos el primer punto del path
        currentPoint = Path.GetPathEnumerator();
        currentPoint.MoveNext();
        //si no hay primer putno salimos
        if (currentPoint.Current == null)
            return;
        //posicionamos el trampolin en el primer punto
        transform.position = currentPoint.Current.position;
	}
	
	// Update is called once per frame
	void Update () {
        // si no hay primer punto o no hay path no se hace nada
        if (currentPoint == null || currentPoint.Current == null)
            return;
        //revisamos el tipo de movimiento para usar MoveTowards o Lerp
        switch(Type)
        {
            case FollowType.MoveTowards:
                transform.position = Vector3.MoveTowards(transform.position, currentPoint.Current.position, Time.deltaTime * speed);
                break;
            case FollowType.Lerp:
                transform.position = Vector3.Lerp(transform.position, currentPoint.Current.position, Time.deltaTime * speed);
                break;
            default:
                break;
        }
        //se checkea la distancia, si se supera la distancia, se pasa al siguiente punto
        float dist = (transform.position - currentPoint.Current.position).sqrMagnitude;
        if (dist < maxDistanceToACheckPoint * maxDistanceToACheckPoint)
            currentPoint.MoveNext();
	}
}
