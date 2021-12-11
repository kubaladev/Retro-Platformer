using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour, ITrap
{

    Animator animator;
    [SerializeField]
    float maxTimeUp=2f;
    [SerializeField]
    float maxTimeDown=4f;
    [SerializeField]
    float startDelay=0f;
    [SerializeField]
    bool startsActive;
    bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    private void Start()
    {
        if (startsActive)
        {
            StartCoroutine(ActivateSpikes(startDelay));
        }
        else
        {
            StartCoroutine(DeactivateSpikes(startDelay));
        }
    }
    IEnumerator ActivateSpikes(float delay)
    {
        isActive = true;
        animator.SetBool("isActivated", true);
        yield return new WaitForSeconds(maxTimeUp - delay);
        StartCoroutine(DeactivateSpikes(0));
    }
    IEnumerator DeactivateSpikes(float delay)
    {
        isActive = false;
        animator.SetBool("isActivated", false);
        yield return new WaitForSeconds(maxTimeDown - delay);
        StartCoroutine(ActivateSpikes(0));
    }

    public bool IsActive()
    {
        return isActive;
    }
}
