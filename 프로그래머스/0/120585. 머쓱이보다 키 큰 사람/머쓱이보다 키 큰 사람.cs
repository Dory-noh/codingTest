using System;

public class Solution {
    public int solution(int[] array, int height) {
        int answer = 0;
        foreach(int h in array){
            if(h > height) answer++;
        }
        return answer;
    }
}