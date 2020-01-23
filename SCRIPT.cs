using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCRIPT : MonoBehaviour
{
    public VideoPlayer movie;
    public Animator anim;
    public Text textVak;
    public GameObject skipPanel0;
    public GameObject filmpje;
    public GameObject skipPanel1;
    public GameObject skipPanel2;
    public GameObject skipPanel3;
    public GameObject skipPanel4;
    public GameObject skipPanel5;
    public GameObject skipPanel6;
    public GameObject skipPanel7;
    public GameObject redBackground;
    public GameObject nextPijl;
    public GameObject ballon1;
    public GameObject ballon2;
    public GameObject ballon3;
    public GameObject ballon4;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(begin());
        StartCoroutine(firstTekst());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator begin(){
        yield return new WaitForSeconds(10);
        Debug.Log("WaitOver");
        movie.Pause();
        skipPanel1.SetActive(true);
        nextPijl.SetActive(true);
    }

    IEnumerator firstTekst(){
        yield return new WaitForSeconds(8);
        skipPanel0.SetActive(true);
        textVak.text = "Hello, my name is Leonardo Da Vinci, but you can call me Leo.";
    }

    
    public void skip1(){
        movie.Play();
        StartCoroutine(begin2());
        skipPanel1.SetActive(false);
        textVak.text = "I used to be the best tour guide of the KMSKA museum, I could answer any question about it."; 
        nextPijl.SetActive(false);  
    }
    public void skip2(){
        movie.Play();
        StartCoroutine(begin3());
        skipPanel2.SetActive(false);
        nextPijl.SetActive(false); 
        textVak.text = "But unfortunately something terrible happened";   
    }
    public void skip3(){
        movie.Play();
        anim.Play("zoom");
        StartCoroutine(begin4());
        skipPanel3.SetActive(false);
        nextPijl.SetActive(false); 
        textVak.text = "Last week I was driving in Antwerp"; 
        ballon1.SetActive(true);  
    }
    public void skip4(){
        movie.Play();
        StartCoroutine(begin5());
        skipPanel4.SetActive(false);
        nextPijl.SetActive(false); 
        textVak.text = "I was bringing the Mona Lisa to the KMSKA museum"; 
        ballon1.SetActive(false);  
        ballon2.SetActive(true);  
    }
    public void skip5(){
        movie.Play();
        StartCoroutine(begin6());
        skipPanel5.SetActive(false);
        nextPijl.SetActive(false); 
        textVak.text = "But suddenly I had an accident with another car";
        ballon2.SetActive(false);  
        ballon3.SetActive(true);  
    }

    public void skip6(){
        movie.Play();
        StartCoroutine(begin7());
        skipPanel6.SetActive(false);
        nextPijl.SetActive(false); 
        textVak.text = "I lost my memory and forgot everything about the museum.";
        ballon3.SetActive(false);  
        ballon4.SetActive(true); 
    }
    public void skip7(){
        anim.Play("inkom");
        skipPanel0.SetActive(false);
        nextPijl.SetActive(false);
        textVak.text = "";
        ballon4.SetActive(false); 
        StartCoroutine(begin8());
        StartCoroutine(begin9());
    }

    IEnumerator begin2(){
        yield return new WaitForSeconds(2);
        skipPanel2.SetActive(true);
        movie.Pause();  
        nextPijl.SetActive(true); 
    }
    IEnumerator begin3(){
        yield return new WaitForSeconds(2);
        skipPanel3.SetActive(true);
        nextPijl.SetActive(true); 
        movie.Pause();  
    }
    IEnumerator begin4(){
        yield return new WaitForSeconds(2);
        skipPanel4.SetActive(true);
        nextPijl.SetActive(true); 
        movie.Pause();  
    }
    IEnumerator begin5(){
        yield return new WaitForSeconds(2);
        skipPanel5.SetActive(true);
        nextPijl.SetActive(true); 
        movie.Pause();  
    }
    IEnumerator begin6(){
        yield return new WaitForSeconds(3);
        skipPanel6.SetActive(true);
        nextPijl.SetActive(true); 
        movie.Pause();  
    }
    IEnumerator begin7(){
        yield return new WaitForSeconds(2);
        skipPanel7.SetActive(true);
        nextPijl.SetActive(true); 
        movie.Pause();  
    }
    IEnumerator begin8(){
        yield return new WaitForSeconds(1);
        redBackground.SetActive(false);
    }
    IEnumerator begin9(){
        yield return new WaitForSeconds(2);
        filmpje.SetActive(false);
        SceneManager.LoadScene("Chatbot", LoadSceneMode.Single);
    }
}


