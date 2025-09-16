using UnityEngine;

public class SpawnDot : MonoBehaviour {
public float time;
public GameObject dot;
void Start() {
InvokeRepeating("Spawn", 0, time);
}
private void Spawn(){
Instantiate(dot, transform.position, transform.rotation);
}
}

