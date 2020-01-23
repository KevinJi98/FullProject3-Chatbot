using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
    public InputField inputBox;
    public Text outputBox;
    public ChatbotInterface chatbot;

    
    
    private void SendMessage()
    {
        chatbot.SendMessage(inputBox.text);
        outputBox.text += System.Environment.NewLine 
                          + inputBox.text
                          + System.Environment.NewLine;
        inputBox.text = "";
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void textReset(){
        outputBox.text = "";
    }

    public void send(){
        if (inputBox.text != "")
        {
            outputBox.text = "";
            SendMessage();
        }
    }

}
