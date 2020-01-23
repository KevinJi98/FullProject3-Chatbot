using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Animator anim;
    public GameObject filmpje;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("uitkom");
        StartCoroutine(begin1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator begin1(){
        yield return new WaitForSeconds(1);
        filmpje.SetActive(false);
    }
}
