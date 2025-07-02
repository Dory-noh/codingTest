using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        //제곱해서 n이 되는 수를 기준으로 짝지은 쌍이 나타나므로 루트 n보다 작은 자연수까지만 for문 돌린다.
        for(int i = 1; i < Math.Sqrt(n); i++){
            if(n%i==0) answer+=2;
        }
        //제곱해서 n이 되는 경우가 있는 경우 - 단일 순서쌍이므로 1만 더한다.
        if(n%Math.Sqrt(n)==0) answer++;
        return answer;
    }
}