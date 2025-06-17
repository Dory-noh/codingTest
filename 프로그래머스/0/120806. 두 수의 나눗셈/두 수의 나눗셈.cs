using System;

public class Solution {
    public int solution(int num1, int num2) {
        int answer =  (int)((Convert.ToDouble(num1) / num2) * 1000) ;
        return answer;
    }
}