using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelLose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
    }

    // Update is called once per frame
    public void Win()
    {
        panelWin.SetActive(true);
    }
   public void Lose()
    { 
        panelLose.SetActive(true);
    }
}
