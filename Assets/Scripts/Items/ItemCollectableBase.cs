using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float itemHideTime = 4;
    public GameObject graphicItem;
    private bool _isCollecting = false;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.transform.CompareTag(compareTag) && (!_isCollecting))
        {   
            _isCollecting = true;
            Collect();
        }
    }

    //virtual é para override de classes

    protected virtual void HideItems()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), itemHideTime);
    }

    protected virtual void Collect()
    {

        HideItems();
        OnCollect();
        
    }

    private void HideObject()
    {
        gameObject.SetActive(false); //na sequencia, criar um bool pra ativar uma animação de destruição de objeto, diminuindo a escala até 0 e na sequencia dando destroy em vez de desativar o objeto

    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null) particleSystem.Play();
        if(audioSource != null) audioSource.Play();
    }
}
