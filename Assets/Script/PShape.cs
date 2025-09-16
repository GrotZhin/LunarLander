using UnityEngine;
public class PShape : MonoBehaviour
{
    //Equivalente ao SphereCollider
    [HideInInspector]
    public Vector3 position;
    public float radiuns;
    public GameObject feet;
    public GameObject pointer;
    public bool isGrounded;

    void Awake()
    {
        position = transform.position;

    }
    void LateUpdate()
    {
         Camera.main.transform.position = position;
    }
}

