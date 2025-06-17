using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int len = num_list.Length;
        int[] answer = new int[len];
        for(int i = 0; i < len; i++) answer[i] = num_list[len-1-i];
        
        return answer;
    }
}