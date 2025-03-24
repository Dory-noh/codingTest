using System;

public class Solution {
    public int[] solution(int n, long left, long right) {
        int len = (int)(right - left + 1);
        int[] answer = new int[len];
        for(long i = left; i <= right; i++){
            answer[(int)(i - left)] = (int)Math.Max(i/n,i%n) + 1;
        } 
        return answer;
    }
}