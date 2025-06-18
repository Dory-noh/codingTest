using System;

public class Solution {
    public string solution(string my_string) {
        string answer = "";
        int len = my_string.Length;
        for(int i = 0; i < len; i++){
            answer+=my_string[len-i-1];
        }
        return answer;
    }
}