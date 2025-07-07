using System;

public class Solution {
    public int solution(int[] num_list) {
        int answer = 0;
        int sum = 0;
        int multiply = 1;
        for(int i = 0; i < num_list.Length; i++){
            sum+=num_list[i];
            multiply*=num_list[i];
        }
        answer = multiply < sum * sum ? 1 : 0;
        return answer;
    }
}