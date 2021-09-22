using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Ui : MonoBehaviour
{

    public Image shield;
    public Image sword;
    public Image magic;

    public Image heroHpBar;
    public Image enemyHpBar;
    
    public CanvasGroup heroActionBadge;
    public CanvasGroup enemyActionBadge;

    public CanvasGroup deadUI;
    public CanvasGroup winUI;
    public CanvasGroup tieUI;

    public Image[] heroBadgeIcon;
    public Image[] enemyBadgeIcon;
    void Start()
    {
        heroHpBar.fillAmount = 1;
        enemyHpBar.fillAmount = 1;

        deadUI.gameObject.SetActive(false);
        winUI.gameObject.SetActive(false);

        deadUI.DOFade(0f, 0f);
        winUI.DOFade(0f, 0f);
       
        heroActionBadge.DOFade(0f, 0f);
        enemyActionBadge.DOFade(0f, 0f);
    }

    public void ShowHeroBadge(string _heroAttack)
    {

        string _iconName = "Icon_" + _heroAttack;
        for (int i = 0; i < heroBadgeIcon.Length; i++)
        {
            if(heroBadgeIcon[i].name == _iconName)
            {
                heroBadgeIcon[i].gameObject.SetActive(true);
            }
        }
        heroActionBadge.DOFade(1f, 1.25f);
        heroActionBadge.GetComponent<RectTransform>().DOAnchorPosY(80, 1.25f);
    }
    
    public void ShowEnemyBadge(string _enemyAttack)
    {
        string _iconName = "Icon_" + _enemyAttack;
        for (int i = 0; i < enemyBadgeIcon.Length; i++)
        {
            if (enemyBadgeIcon[i].name == _iconName)
            {
                enemyBadgeIcon[i].gameObject.SetActive(true);
            }
        }
        enemyActionBadge.DOFade(1f, 1.25f);
        enemyActionBadge.GetComponent<RectTransform>().DOAnchorPosY(80, 1.25f);
    }


    public void HideBadges()
    {
        heroActionBadge.DOFade(0f, 0.25f);
        heroActionBadge.GetComponent<RectTransform>().DOAnchorPosY(-80, 0f).SetDelay(0.25f).OnComplete(HideBadgeIcon);
        enemyActionBadge.DOFade(0f, 0.25f);
        enemyActionBadge.GetComponent<RectTransform>().DOAnchorPosY(-80, 0f).SetDelay(0.25f);
    }

    private void HideBadgeIcon()
    {
        for (int i = 0; i < enemyBadgeIcon.Length; i++)
        {
           enemyBadgeIcon[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < heroBadgeIcon.Length; i++)
        {
            heroBadgeIcon[i].gameObject.SetActive(false);
        }
    }

    public void UpdateBar(int _barType, float _amount)
    {
        
        if(_barType == 1)
        {
            float _hitPoints = heroHpBar.fillAmount - _amount;
            heroHpBar.fillAmount = _hitPoints;
        } 
        else
        {
            float _hitPoints = enemyHpBar.fillAmount - _amount;
            enemyHpBar.fillAmount = _hitPoints;
        }
    }
    public void ShowDeadUi()
    {
        deadUI.gameObject.SetActive(true);
        deadUI.DOFade(1f, 1f);
    }

    public void ShowWinUi()
    {
        winUI.gameObject.SetActive(true);
        winUI.DOFade(1f, 1f);
    }

    public void ShowTie()
    {
        tieUI.DOFade(1, 0.5f);
        tieUI.DOFade(0, 0.5f).SetDelay(1.5f);
    }

    public void EnableButtons()
    {
        shield.GetComponent<CanvasGroup>().DOFade(1f, 0.25f);
        sword.GetComponent<CanvasGroup>().DOFade(1f, 0.25f);
        magic.GetComponent<CanvasGroup>().DOFade(1f, 0.25f);

        shield.GetComponent<Button>().interactable = true;
        sword.GetComponent<Button>().interactable = true;
        magic.GetComponent<Button>().interactable = true;
    }
    
    public void DisableButtons()
    {
        shield.GetComponent<CanvasGroup>().DOFade(0.25f, 0.25f);
        sword.GetComponent<CanvasGroup>().DOFade(0.25f, 0.25f);
        magic.GetComponent<CanvasGroup>().DOFade(0.25f, 0.25f);

        shield.GetComponent<Button>().interactable = false;
        sword.GetComponent<Button>().interactable = false;
        magic.GetComponent<Button>().interactable = false;
    }
}
