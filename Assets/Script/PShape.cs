using UnityEngine;
public class PShape : MonoBehaviour
{
    //Equivalente ao SphereCollider
    [HideInInspector]
    public Vector3 position;
    public Vector3 cam;
    public float radiuns;
    public GameObject feet;
    public GameObject pointer;
    public bool isGrounded;

    void Awake()
    {
        position = transform.position;
        cam = Camera.main.transform.position;

    }
    void FixedUpdate()
    {
         Camera.main.transform.position = cam = new Vector3 (position.x, position.y, cam.z) ;
    }
}

