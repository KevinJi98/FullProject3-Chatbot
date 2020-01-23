using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject camera;
    public GameObject chat;
    public GameObject ARcam;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject scan;
    public Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonCam(){
        anim2.Play("cam");
        camera.SetActive(false);
        chat.SetActive(true);
        StartCoroutine(begin());
        canvas.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        scan.SetActive(true);
        
    }
    public void buttonChat(){
        anim2.Play("chat");
        camera.SetActive(true);
        ARcam.SetActive(false);
        chat.SetActive(false);
        canvas.SetActive(true);
        canvas2.SetActive(true);
        canvas3.SetActive(true);
        scan.SetActive(false);
    }
    IEnumerator begin(){
        yield return new WaitForSeconds(1);
        ARcam.SetActive(true);
    }
  
}
