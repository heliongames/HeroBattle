using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    private Animator animator;
    public bool hasWeapon;
    public float hitPoints = 1f;
    
    void Start()
    {
        SetupParameters();
        SetAnimation();
    }
   
    private void SetupParameters()
    {
        animator = GetComponent<Animator>();
    }

    private void SetAnimation()
    {
        int _id = UnityEngine.Random.Range(0, 3);
        if (_id == 1)
        {
            animator.SetTrigger("Idle2");
        }
        else if(_id == 2)
        {
            animator.SetTrigger("Idle3");
        }
    }
     
    public void Attack()
    {
        if (hasWeapon)
        {
            animator.SetTrigger("Melee");
        } 
        else
        {
            if(UnityEngine.Random.value > 0.5f)
            {
                animator.SetTrigger("Punch");
            } 
            else
            {
                animator.SetTrigger("Swipe");
            }
        }
    }
    
    public void Hit(float _damage)
    {
        hitPoints = hitPoints - _damage;
        if(hitPoints > 0)
        {
            animator.SetTrigger("Hit");
        } else
        {
            animator.SetTrigger("Die");
        }
        
    }
}
