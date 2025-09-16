using Sfx;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Physic : MonoBehaviour
{
    public float gravity;
    public GameManager gm;
    public PShape shape;
    public PlayerMove player;
    public GameObject xploz;
    Vector3 inicialPosition;
    public float speed;
    public float timer;
    int mult;
    public int score;
    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shape = GetComponent<PShape>();
        player = GetComponent<PlayerMove>();
        gm = gameObject.GetComponent<GameManager>();
        inicialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaPercorrida = Vector3.Distance(shape.position, inicialPosition);


        speed = distanciaPercorrida / Time.deltaTime;


        inicialPosition = transform.position;

        mult = Mult(player.gas);
    }
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(shape.feet.transform.position, transform.TransformDirection(-Vector2.up), out hit, 0.1f))
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
        Collider[] c = Physics.OverlapCapsule(shape.feet.transform.position, shape.pointer.transform.position, 0.1f, layerMask);
        if (c.Length > 0)
        {
            Destroy(this.gameObject, timer);
            
            //chamar animacao da nave detonada
            gm.Lose();
        }
    }
    void OnDestroy()
    {
        soundManager.PlaySound(SoundType.Blow);
        Instantiate(xploz,transform.position,Quaternion.identity);
    }
    void ODrawGizmos()
    {
        Gizmos.DrawWireSphere(shape.feet.transform.position, 0.5f);
    }
    void WinCondition(PShape shape)
    {
        if (shape.transform.transform.localEulerAngles.z <= 20 || shape.transform.transform.localEulerAngles.z >= -20 && speed < 20)
        {
            shape.isGrounded = true;
            score = 100 * mult;
            Debug.Log("win");
            gm.Win();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public int Mult(float gas)
    {
        if (gas >= 90)
            return 9;
        if (gas < 90 && gas >= 75)
            return 7;
        if (gas < 75 && gas >= 45)
            return 5;
        if (gas < 45 && gas >= 25)
            return 3;
        else return 1;
    }
}
