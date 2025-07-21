using System;

public class Solution {
    public int solution(string t, string p) {
        int answer = 0;
        //메서드 중복 호출 최소화를 위한 변수 선언
        int pLen = p.Length;
        //p의 길이가 최대 18자리이므로 long형으로 p를 받음
        long pToInt = long.Parse(p);
        for(int i = 0; i+pLen <= t.Length; i++){
            //현재 인덱스값에서 p길이의 t 부분 문자열을 정수형으로 형변환하여 temp에 저장함.
            //for문 내부에서만 사용하므로 지역변수로 temp 선언
            //p의 길이가 최대 18자리이므로 long형으로 temp를 받음
            long temp = long.Parse(t.Substring(i,pLen));
            if(temp <= pToInt) answer++;
        }
        return answer;
    }
}