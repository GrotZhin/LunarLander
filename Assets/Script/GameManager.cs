using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelLose;
    public TextMeshProUGUI textScore;
    public Physic physic;
    string scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        scene = SceneManager.GetActiveScene().name;
        Debug.Log("aaaaaaa: " + scene);
    }

    // Update is called once per frame
    public void Win()
    {
        textScore.text = "Score: " + physic.score;

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
    [ContextMenu("Retry")]
    public void Retry()
    {
        SceneManager.LoadScene(scene);

    }
    
}
