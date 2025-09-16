using Unity.VisualScripting;
using UnityEngine;

public class timdist : MonoBehaviour
{
    public float time = 0;
    
        void Update()
        {
        Destroy(this.gameObject, time);
        }
}
