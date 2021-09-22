using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private Ui ui;
    [SerializeField]
    private Char hero;
    [SerializeField]
    private Char enemy;
    [SerializeField]
    private float damage;
    private bool isGame;
    
    void Start()
    {
        ui = GetComponent<Ui>();
        isGame = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_heroAttack"></param>
    public void DoAttack(string _heroAttack)
    {
        string _enemyAttack = GenerateEnemyAttackType();
        ui.DisableButtons();
        ui.ShowHeroBadge(_heroAttack);
        ui.ShowEnemyBadge(_enemyAttack);
        
        if (isGame)
        {
            if (_heroAttack == "sword" && _enemyAttack == "sword" || _heroAttack == "magic" && _enemyAttack == "magic" || _heroAttack == "shield" && _enemyAttack == "shield")
            {
                ui.ShowTie();
            }
            else if (_heroAttack == "sword" && _enemyAttack == "magic")
            {
                hero.Attack();
                enemy.Hit(damage);
                ui.UpdateBar(2, damage);
            }
            else if (_heroAttack == "shield" && _enemyAttack == "sword")
            {
                hero.Attack();
                enemy.Hit(damage);
                ui.UpdateBar(2, damage);
            }
            else if (_heroAttack == "magic" && _enemyAttack == "shield")
            {
                hero.Attack();
                enemy.Hit(damage);
                ui.UpdateBar(2, damage);
            }
            else if (_heroAttack == "shield" && _enemyAttack == "magic")
            {
                hero.Hit(damage);
                enemy.Attack();
                ui.UpdateBar(1, damage);
            }
            else if (_heroAttack == "sword" && _enemyAttack == "shield")
            {
                hero.Hit(damage);
                enemy.Attack();
                ui.UpdateBar(1, damage);
            }
            else if (_heroAttack == "magic" && _enemyAttack == "sword")
            {
                hero.Hit(damage);
                enemy.Attack();
                ui.UpdateBar(1, damage);
            }
            CheckCharHitPoints();
        }
        StartCoroutine(HideBadges());
    }

    IEnumerator HideBadges()
    {
        yield return new WaitForSeconds(1.5f);
        ui.HideBadges();
    }
    
    IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(2f);
        ui.EnableButtons();
    }
    
    IEnumerator ShowDeadUI()
    {
        yield return new WaitForSeconds(2f);
        ui.ShowDeadUi();
    }
    
    IEnumerator ShowWinUI()
    {
        yield return new WaitForSeconds(2f);
        ui.ShowWinUi();
    }

    private void CheckCharHitPoints()
    {
        if(hero.hitPoints <= 0)
        {
            isGame = false;
            StartCoroutine(ShowDeadUI());
        }
        else if(enemy.hitPoints <= 0)
        {
            isGame = false;
            StartCoroutine(ShowWinUI());
        } 
        else
        {
            StartCoroutine(EnableButtons());
        }
    }

    private string GenerateEnemyAttackType()
    {
        string _type = "";
        int _id = UnityEngine.Random.Range(0, 3);
        if (_id == 0)
        {
            _type = "sword";
        }
        else if (_id == 1)
        {
            _type = "magic";
        }
        else if (_id == 2)
        {
            _type = "shield";
        }
        return _type;
    }

    public void ToMenu()
    {
        SimpleSceneFader.ChangeSceneWithFade("Menu");
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
