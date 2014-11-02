using UnityEngine;
using System.Collections;

public enum powerType {
    none,
    stopCalories,
}

public class energia : MonoBehaviour {

    public float calorias = 10f;
    public powerType type = powerType.none;
}
