using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Dialogue
{
    public string[] name;
    [TextArea(3, 10)]
    public string[] playerSentences;
    
    [TextArea(3, 10)]
    public string[] conversationSentences;

    [TextArea(1, 5)]
    public string[] centreText;

}
