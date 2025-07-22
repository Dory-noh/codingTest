using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        //3진법으로 변환 + 뒤집어서
        long nLong = 0;
        string temp = "";
        while(n!=0){
            temp = temp + (n%3).ToString();
            n/=3;
        }
        //3진수 변환시 10자리 넘어가므로 long형으로 변환
        nLong = long.Parse(temp);
        //10진법으로 표현
        for(int i = 0; i < temp.Length; i++){
            answer += (int)((nLong%10)*(Math.Pow(3,i)));
            nLong/=10;
        }
        
        
        return answer;
    }
}