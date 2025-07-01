using System;

public class Solution {
    public int solution(string[] s1, string[] s2) {
        int answer = 0;
        Array.Sort(s1);
        Array.Sort(s2);
        foreach(string s1Str in s1){
            foreach(string s2Str in s2){
                //s2의 앞 글자가 s1의 앞 글자보다 사전 순에서 같거나 앞 쪽에 같은 경우까지만 비교 
                if(s1Str[0] < s2Str[0]){
                    break;
                }
                if(String.Compare(s1Str, s2Str) == 0) {
                    answer++;
                }
            }
        }
        return answer;
    }
}