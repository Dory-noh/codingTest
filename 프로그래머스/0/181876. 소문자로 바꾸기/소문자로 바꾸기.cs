using System;

public class Solution {
    public string solution(string myString) {
        string answer = "";
        for(int i = 0; i < myString.Length; i++){
            string ch = myString[i] + "";
            if(ch[0] >= 'A') ch = ch.ToLower();
            answer+=ch;
        }
        return answer;
    }
}