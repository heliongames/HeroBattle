using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup tutorialUI;
    public void PlayGame()
    {
        SimpleSceneFader.ChangeSceneWithFade("Game");
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
