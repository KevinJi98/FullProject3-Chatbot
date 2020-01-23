/**
* (C) Copyright IBM Corp. 2018, 2019.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/
#pragma warning disable 0649

using System.Collections;
using IBM.Cloud.SDK;
using IBM.Cloud.SDK.Authentication;
using IBM.Cloud.SDK.Authentication.Iam;
using IBM.Cloud.SDK.Utilities;
using IBM.Watson.Assistant.V2;
using IBM.Watson.Assistant.V2.Model;
using UnityEngine;
using UnityEngine.UI;

public class ChatbotInterface : MonoBehaviour
{
    #region PLEASE SET THESE VARIABLES IN THE INSPECTOR
    [Space(10)]
    [Tooltip("The IAM apikey.")]
    [SerializeField]
    private string iamApikey;
    [Tooltip("The service URL (optional). This defaults to \"https://gateway.watsonplatform.net/assistant/api\"")]
    [SerializeField]
    private string serviceUrl;
    [Tooltip("The version date with which you would like to use the service in the form YYYY-MM-DD.")]
    [SerializeField]
    private string versionDate;
    [Tooltip("The assistantId to run the example.")]
    [SerializeField]
    private string assistantId;
    #endregion

    private AssistantService service;
    private bool createSessionTested = false;
    private string sessionId;
    
    public Text outputBox;

    public void targetFound(){
        
        DeleteSession();
         assistantId = "8f07aa69-8338-461b-a0e9-45b6e5f6ab8c";
         Runnable.Run(CreateService());
        
        

    }

    private void Start()
    {
        LogSystem.InstallDefaultReactors();
        
        Runnable.Run(CreateService());
    }
    
    private IEnumerator CreateService()
    {
        if (string.IsNullOrEmpty(iamApikey))
        {
            throw new IBMException("Plesae provide IAM ApiKey for the service.");
        }

        //  Create credential and instantiate service
        IamAuthenticator authenticator = new IamAuthenticator(apikey: iamApikey);

        //  Wait for tokendata
        while (!authenticator.CanAuthenticate())
            yield return null;

        service = new AssistantService(versionDate, authenticator);
        if (!string.IsNullOrEmpty(serviceUrl))
        {
            service.SetServiceUrl(serviceUrl);
        }
        Runnable.Run(CreateSession());
    }
    
    

    private IEnumerator CreateSession()
    {
        Log.Debug("ExampleAssistantV2.RunExample()", "Attempting to CreateSession");
        service.CreateSession(OnCreateSession, assistantId);

        while (!createSessionTested)
        {
            yield return null;
        }
    }

    private void OnCreateSession(DetailedResponse<SessionResponse> response, IBMError error)
    {
        Log.Debug("chatbot.OnCreateSession()", "Session: {0}", response.Result.SessionId);
        sessionId = response.Result.SessionId;
        createSessionTested = true;

        StartConversation();
    }
    

    
    private void StartConversation()
    {
        service.Message(OnStartConversation, assistantId, sessionId);
    }
    
    private void OnStartConversation(DetailedResponse<MessageResponse> response, IBMError error)
    {
        outputBox.text += System.Environment.NewLine
                            + response.Result.Output.Generic[0].Text
                            + System.Environment.NewLine;
    }
    
    

    public void SendMessage(string messageText)
    {
        var input1 = new MessageInput()
        {
            Text = messageText,
            Options = new MessageInputOptions()
            {
                ReturnContext = true
            }
        };

        service.Message(OnMessage, assistantId, sessionId, input: input1);
    }
    
    private void OnMessage(DetailedResponse<MessageResponse> response, IBMError error)
    {
        var responseText = response.Result.Output.Generic;
        var responseLength = responseText.Count;
        outputBox.text += System.Environment.NewLine
                          + responseText[0].Text
                          + System.Environment.NewLine;
    }
    
    

    public void DeleteSession()
    {
        Log.Debug("assistant.RunExample()", "Attempting to delete session");
        service.DeleteSession(OnDeleteSession, assistantId, sessionId);
    }

    private void OnDeleteSession(DetailedResponse<object> response, IBMError error)
    {
        Log.Debug("assistant.OnDeleteSession()", "Session deleted.");
    }
}
