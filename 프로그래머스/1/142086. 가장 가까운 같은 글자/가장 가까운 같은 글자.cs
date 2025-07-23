using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string s) {
        int[] answer = new int[s.Length];
        //문자열에 들어간 글자와 탐색 중 글자가 발견된 가장 최근 인덱스값을 저장할 딕셔너리
        Dictionary<char, int> wordDict= new Dictionary<char, int> {};
        
        //문자열 끝 열까지 검사
        for(int i = 0; i < s.Length; i++){
            //이미 딕셔너리에 등록된 글자일 경우
            if(wordDict.ContainsKey(s[i])) {
                //딕셔너리에 등록된 글자의 인덱스값과 현재 글자의 인덱스 값 차를 answer 배열에 등록
                answer[i] = i - wordDict[s[i]];
                //딕셔너리에 등록된 글자의 인덱스 값을 현재 글자 인덱스 위치로 변경
                wordDict[s[i]] = i;
            }
            //아직 딕셔너리에 등록되어 있지 않은 글자인 경우
            else {
                //-1 표시
                answer[i] = -1;
                //딕셔너리에 해당 글자, 현재 인덱스값 등록
                wordDict.Add(s[i],i);
            }
        }
        return answer;
    }
}