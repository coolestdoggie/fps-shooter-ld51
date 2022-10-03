using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Target : MonoBehaviour
{
    public event Action HpUpdated;
    
    public float health = 5.0f;
    public int pointValue;
    public bool isPlayer;

    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    
    public bool Destroyed => m_Destroyed;

    bool m_Destroyed = false;
    public float CurrentHealth { get; private set; }

    void Awake()
    {
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        isPlayer = CompareTag("Player");
        if(DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);
        
        CurrentHealth = health;
        if(IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);
    }

    public void Got(float damage)
    {
        CurrentHealth -= damage;
        OnHpUpdated();
        
        if(HitPlayer != null)
            HitPlayer.PlayRandom();
        
        if(CurrentHealth > 0)
            return;

        Vector3 position = transform.position;
        
        //the audiosource of the target will get destroyed, so we need to grab a world one and play the clip through it
        if (HitPlayer != null)
        {
            var source = WorldAudioPool.GetWorldSFXSource();
            source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }

        if (DestroyedEffect != null)
        {
            var effect = PoolSystem.Instance.GetInstance<ParticleSystem>(DestroyedEffect);
            effect.time = 0.0f;
            effect.Play();
            effect.transform.position = position;
        }

        m_Destroyed = true;
        
        if (!isPlayer)
        {
        gameObject.SetActive(false);
        }
        else
        {
            FinalScoreUI.Instance.Display();
        }
       
        GameSystem.Instance.TargetDestroyed(pointValue);
    }

    public void Heal(int toHeal)
    {
        CurrentHealth += toHeal;
        health = Mathf.Min(CurrentHealth, health);
        OnHpUpdated();
    }

    protected virtual void OnHpUpdated()
    {
        HpUpdated?.Invoke();
    }
}
