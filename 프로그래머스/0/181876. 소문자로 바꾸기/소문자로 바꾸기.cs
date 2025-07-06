using System;

public class Solution {
    public string solution(string myString) {
        string answer = "";
        for(int i = 0; i < myString.Length; i++){
            char ch = myString[i];
            if(ch >= 'A') ch = char.ToLower(ch);
            answer+=ch;
        }
        return answer;
    }
}