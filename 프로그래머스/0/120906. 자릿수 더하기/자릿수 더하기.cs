using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        string numStr = n.ToString();
        foreach(char numChar in numStr) 
            answer+=numChar-'0';
        return answer;
    }
}