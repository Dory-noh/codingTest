using System;
using System.Collections.Generic;

public class Solution {
    public string solution(string s, string skip, int index) {
        string answer = "";
        
        //알파벳 리스트 생성 및 초기화한다.
        List<char> alphaList= new List<char> {};
        
        for(char ch = 'a'; ch <= 'z'; ch++){
            alphaList.Add(ch);
        }
        
        //건너뛸 알파벳을 알파벳 리스트에서 제거한다.
        foreach(char ch in skip){
            alphaList.Remove(ch);
        }
        
        //바꿀 문자의 위치를 찾고 index를 더한다. 알파벳 리스트 범위를 넘어갈 경우 다시 앞쪽부터 찾도록 나머지 연산을 해주었다.
        foreach(char ch in s){
            answer += alphaList[(alphaList.FindIndex(x=>x.Equals(ch))+index)%alphaList.Count];
        }
        
        return answer;
    }
}