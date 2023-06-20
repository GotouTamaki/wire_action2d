using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //[SerializeField] Image[] _images = new Image[2];
    //[SerializeField] Color _selectColor = Color.white;

    AudioSource _se = default;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        _se = GetComponent<AudioSource>();        
    }

    public void  GameOver(string stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleScene()
    {
        //Debug.Log("TitleScene");
        SceneManager.LoadScene("TitleScene");
    }

    public void StageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OperationExplanation()
    {
        SceneManager.LoadScene("OperationExplanation");
    }

    public void StageTutorial()
    {
        SceneManager.LoadScene("Stage_Tutorial");
    }

    public void Stage_1()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void Stage_2()
    {
        SceneManager.LoadScene("Stage_2");
    }

    public void Stage_3()
    {
        SceneManager.LoadScene("Stage_3");
    }
}