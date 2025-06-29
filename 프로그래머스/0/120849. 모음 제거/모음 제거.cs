using System;

public class Solution {
    public string solution(string my_string) {
        string answer = "";
        string vowels = "aeiou";
        foreach(char vowel in vowels){
            my_string = my_string.Replace(vowel.ToString(),"");
        }
        return answer = my_string;
    }
}