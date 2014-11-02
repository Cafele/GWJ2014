using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class pathController : MonoBehaviour
{
    //lista de transform que forman los puntos del path
    public Transform[] Path;
    //ienumerator para facilitar el movimiento zigzag
    public IEnumerator<Transform> GetPathEnumerator()
    {
        //el path no debe ser nulo y debe tener al menos 1 punto
        if (Path == null || Path.Length < 1)
            yield break;
        //direccion en la cual se avanza en la lista de puntos
        int dir = 1;
        //indice de la lista de puntos 
        int index = 0;
        //pseudo update
        while (true)
        {
            //se devuelve el punto en el index
            yield return Path[index];
            // si el path contiene un solo punto no se continua
            if (Path.Length == 1)
                continue;
            //si el indice es 0, se continua en positivo
            if (index <= 0)
            {
                dir = 1;
            }
                //si el indice llega al ultimo punto se continua hacia abajo en negativo
            else if (index >= (Path.Length -1)){
                dir = -1;
            }
            //se adelanta el indice
            index = index + dir;
        }
    }

    //solo para ver el path visible
    public void OnDrawGizmos()
    {
        //tiene que haber al menos 2 puntos para dibujar una linea
        if (Path == null || Path.Length < 2)
            return;
        // dibujo linea entre dos pares de puntos
        for (int i = 1; i < Path.Length; i++)
        {
            Gizmos.DrawLine(Path[i-1].position,Path[i].position);
        }
        
    }

}
