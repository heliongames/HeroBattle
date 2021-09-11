using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu : MonoBehaviour
{

    public CanvasGroup tutorialUI;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowTutorial()
    {
        tutorialUI.DOFade(1, 0.5f);
        tutorialUI.blocksRaycasts = true;
    }
    
    public void HideTutorial()
    {
        tutorialUI.DOFade(0, 0.5f);
        tutorialUI.blocksRaycasts = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
