using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Gravity : MonoBehaviour
{
    public float gravity;
    public float distance;
    public PShape shape;
    public GameObject plat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shape = GetComponent<PShape>();
        plat = GameObject.FindGameObjectWithTag("Ground");
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    void FixedUpdate()
    {
         RaycastHit hit;

        if (Physics.Raycast(shape.position, transform.TransformDirection(-Vector2.up), out hit, distance))
        {

            if (hit.collider.tag == "Ground")
            {
                Debug.DrawRay(shape.position, transform.TransformDirection(-Vector2.up) * hit.distance, Color.red);
                
                shape.isGrounded = true;

            }
            if (Vector3.Distance(shape.position, plat.transform.position) > 1)
            {
                shape.isGrounded = false;
            }
        }
        if (shape.isGrounded == false)
        {
            shape.position.y += gravity * Time.fixedDeltaTime;
        }
    }
}
