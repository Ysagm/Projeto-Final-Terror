using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

using UnityEngine.EventSystems;

using Photon.Pun;
using Photon.Chat;


public class ChatController : MonoBehaviour
{
    public TMP_InputField chatInput;
    public TextMeshProUGUI chatContent;
    private PhotonView photonView;
    private List<string> messages = new List<string>();
    private float delay = 0f;
    private int maxMessages = 5;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    [PunRPC]
    void RPC_AddNewMessages(string msg)
    {
        messages.Add(msg);
    }

    public void SendChat(string msg)
    {
        
        string NewMessage = msg;
        photonView.RPC("RPC_AddNewMessages", RpcTarget.All, NewMessage);
    }

    public void SubmitChat()
    {
        string blankCheck = chatInput.text;
        blankCheck = Regex.Replace(blankCheck, @"\s", "");
        if(blankCheck == "")
        {
            chatInput.text = "";
            return;
        }

        SendChat(chatInput.text);
        //chatInput.ActivateInputField();
        chatInput.text = "";

        EventSystem.current.SetSelectedGameObject(null);

    }

    void ChatContents()
    {
        string newContents = "";
        foreach(string s in messages)
        {
            newContents += s + "\n";
        }
        chatContent.text = newContents;
    }


    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.InRoom)
        {
            chatContent.maxVisibleLines = maxMessages;

            if(messages.Count>maxMessages)
            {
                messages.RemoveAt(0);
            }
            if(delay<Time.time)
            {
                ChatContents();
                delay = Time.time + 0.25f;
            }
        }
        else if(messages.Count>0)
        {
            messages.Clear();
            chatContent.text = "";
        }
    }
}

