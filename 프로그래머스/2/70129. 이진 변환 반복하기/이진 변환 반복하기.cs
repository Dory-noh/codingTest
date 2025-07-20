using System;

public class Solution {
    public int[] solution(string s) {
        int[] answer = new int[2];
        string temp = "";
        int len = s.Length;
        while(s != "1"){
            answer[0]++; //이진 변환 횟수 카운트 1 증가 시킴
            //1. 문자열에서 0을 제거하는 part
            temp = "";
            len = s.Length;
            for(int i = 0 ; i < len; i++){
                if(s[i]=='1') temp += "1";
                else answer[1]++; //제거된 0의 개수 카운트 증가 시킴
            }
            len = temp.Length;
            
            temp = "";
            //2. 이진 변환을 하는 part
            while(len != 0){
                temp = (len%2).ToString() + temp;
                len /=2;
            }
            s = temp;
            
        }
        return answer;
    }
}