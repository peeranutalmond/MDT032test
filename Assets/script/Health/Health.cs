using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(hurtSound);
        }
       
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
                
                
                 
                    SceneManager.LoadScene("MainMenu");
                

                
            }
        }
        
        
    }
    
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}