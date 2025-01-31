using System;

public class Solution {
    public int solution(string s) {
        //변수 선언 및 초기화
        int answer = 0;
        char pivot = s[0];
        int pivotCount = 0;
        int otherCount = 0;
        //반복문을 이용하여 문자열 끝까지 체크한다.
        for(int i = 0; i < s.Length; i++){
            //pivot과 같은 문자열이면 pivotCount를 아니면 otherCount를 1 증가시킨다.
            if(s[i] == pivot) pivotCount++;
            else otherCount++;
            //모든 문자열 검사를 끝낸 경우, 두 Count 크기에 관계없이 answer를 1 증가시킨 후 종료.
            if(i == s.Length - 1){
                answer++;
                break;
            }
            //문자열 검사 도중 두 Count 변숫값이 동일한 경우 answer를 1 증가시키고 두 Count 변수 초기화한다.
            if(pivotCount == otherCount)
            {
                pivotCount = 0;
                otherCount = 0;
                pivot = s[i+1];
                answer++;
            }
        }
        return answer;
    }
}