using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelLose;
    public TextMeshProUGUI scoreTxt;
    public Physic physic;
    string scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        scene = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    public void Win()
    {
        scoreTxt.text = "Score: " + physic.score;
        panelWin.SetActive(true);
    }
    public void Lose()
    {
        panelLose.SetActive(true);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("level2");
    }
    
    public void Retry()
    {
        Debug.Log("aa: " + scene);
        SceneManager.LoadScene(scene);
        
    }
}
