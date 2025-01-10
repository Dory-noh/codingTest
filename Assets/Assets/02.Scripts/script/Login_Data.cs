using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Login_Data", menuName = "Data/Login_Data")]
public class Login_Data : ScriptableObject
{
    public string Username;
    public string Token;
}
