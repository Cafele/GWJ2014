using UnityEngine;
using System.Collections;

public class hideController : MonoBehaviour {
    //tiempo escondido
    public float hideTime = 1f;
    //tiempo que se muestra
    public float showTime = 1f;
    //variable que define si el trampoline se escondio
    private bool hidden = false;
    //funcion que espera un tiempo y luego esconde
	private IEnumerator waitToHide()
    {
        yield return new WaitForSeconds(showTime);
        setChildActiveTo(false);
        hidden = true;
    }
    //funcion que espera un tiempo y luego muestra
    private IEnumerator waitToShow()
    {
        yield return new WaitForSeconds(hideTime);
        setChildActiveTo(true);
        hidden = false;
    }
	// Update is called once per frame
	void Update () {
        if (hidden)
        {
            //si esta oculto corro la funcion para mostrar
            StartCoroutine(waitToShow());
            
        }
        else 
        {
            //si se esta mostrando corro la funcion para ocultar
            StartCoroutine(waitToHide());
            
        }
        
    }
    //funcion que setea a todos los hijos como activos o no activos segun un booleano que reciba
    private void setChildActiveTo(bool active)
    {
        for (int i = 0; i < transform.childCount; ++i)
            transform.GetChild(i).gameObject.SetActive(active);
    }
}
