using UnityEngine;
public class PShape : MonoBehaviour
{
    //Equivalente ao SphereCollider
    [HideInInspector]
    public Vector3 position;
    public float radiuns;
    public GameObject feet;
    public bool isGrounded;
    void Awake()
    {
        position = transform.position;
        
    }
}

