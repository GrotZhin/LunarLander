using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Gravity : MonoBehaviour
{
    public float gravity;
    public float distance;
    public float height;
    public PShape shape;
    public GameObject start;
    public GameObject end;
    BoxCollider box;
    Vector3 inicialPosition;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shape = GetComponent<PShape>();
        end = GameObject.FindGameObjectWithTag("End");
        start = GameObject.FindGameObjectWithTag("Start");
        inicialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaPercorrida = Vector3.Distance(shape.position, inicialPosition);

        
        speed = distanciaPercorrida / Time.deltaTime;
        
        
        inicialPosition = transform.position;


    }
    void FixedUpdate()
    {
        RaycastHit hit;
            
        if (Physics.Raycast(shape.feet.transform.position, transform.TransformDirection(-Vector2.up), out hit, 0.5f))
        {

            if (hit.collider.tag == "Start")
            {
                shape.isGrounded = true;
                Debug.DrawRay(shape.feet.transform.position, transform.TransformDirection(-Vector2.up) * hit.distance, Color.red);
               

            }
            if (hit.collider.tag == "End")
            {
                Debug.DrawRay(shape.feet.transform.position, transform.TransformDirection(-Vector2.up) * hit.distance, Color.red);
                WinCondition(shape);
            }

        }
        if (shape.isGrounded == false)
        {
            shape.position.y += gravity * Time.fixedDeltaTime;
        }
    }
    void WinCondition(PShape shape)
    {
        if (shape.transform.transform.localEulerAngles.z <= 20 && shape.transform.transform.localEulerAngles.z >= -20 )
        {
            shape.isGrounded = true;
            Debug.Log("win");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
