using System;

public class Solution {
    public string solution(string my_string) {
        string answer = "";
        string vowelArr = "aeiou";
        foreach(char ch in my_string){
            bool isVowel = false;
            foreach(char vowel in vowelArr){
                if(ch == vowel) {
                    isVowel = true;
                    break;
                }
            }
            if(isVowel == false) answer+=ch;
        }
        return answer;
    }
}