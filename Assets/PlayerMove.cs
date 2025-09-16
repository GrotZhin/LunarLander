using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class PBody : MonoBehaviour
{
    [HideInInspector]
    public PShape shape;
    public float thrusterSpeed;
    public float rotationSpeed;
    public GameObject pointer;
    public float gas;
    public bool isStatic;
    [Header("Info")]
    public Vector3 velocity;
    void Start()
    {
        shape = GetComponent<PShape>();
    }
    void FixedUpdate()
    {
        KinematicMotion();
        if (!isStatic) transform.position = shape.position;

    }
    void KinematicMotion()
    {
        shape.position += velocity * Time.fixedDeltaTime;
    }


    public bool isPlayer;
    void Update()
    {
        if (isPlayer && gas > 0)
        {
            Vector3 dir = new Vector3();

            dir.y = Input.GetAxis("Vertical");
            dir.x = Input.GetAxis("Horizontal");



            transform.Rotate(0, 0, -dir.x * rotationSpeed * Time.deltaTime);
            shape.position += pointer.transform.up * dir.y * thrusterSpeed * Time.deltaTime;
            shape.position += Vector3.right * dir.x * thrusterSpeed/9 * Time.deltaTime;
            
            if (dir.x > 0)
            {
                //anim Turbina esquerda
                gas -= 2 * Time.deltaTime;
            }

            if (dir.x < 0)
            {
                //anim Turbina direita
                gas -= 2 * Time.deltaTime;
            }
            if (dir.y > 0)
            {
                shape.isGrounded = false;
                gas -= 4 * Time.deltaTime;
            }else
            {
                shape.isGrounded = false;
            }
        }
    }
   
}
 

     

      

