using System;
using System.Linq;

public class Solution {
    public int solution(int[] num_list) {
        int answer = 0;
        int len = num_list.Length;
        if(len >= 11){
            answer = num_list.Sum();
        }
        else{
            answer = 1;
            for(int i = 0; i < len; i++) answer*=num_list[i];
        }
        return answer;
    }
}