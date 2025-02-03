using System;

public class Solution {
    public int solution(int n, int m, int[] section) {
        int answer = 1;
        int idx = 0;
        //가장 작은 section에서 m만큼을 칠할 수 있는 범위(검사용 변숫값으)로 잡음
        int range = section[0] + m;
        //끝까지 칠한 경우 반복문을 끝냄.
        while(idx != section.Length){
            //칠할 수 있는 범위를 넘어간 경우 range 재설정 및 answer++;
            if(section[idx] >= range) {
                answer++;
                range = section[idx] + m;
            }
            //칠할 수 있는 범위 내의 section인 경우, idx값만 1 더함.
            else idx++;
        }
        return answer;
    }
}