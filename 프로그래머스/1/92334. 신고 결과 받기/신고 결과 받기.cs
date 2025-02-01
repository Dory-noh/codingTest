using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] id_list, string[] report, int k) {
        int[] answer = new int[id_list.Length];
        report = report.Distinct().ToArray(); //중복 신고 제거
        
        //신고된 id를 담는 idDict, 
        //신고한 계정 id를 담는 reportDict, Dictionary 선언 및 초기화
        Dictionary<string, string> idDict = id_list.ToDictionary(str => str, _ => "");
        Dictionary<string, int> reportDict = id_list.ToDictionary(str => str, _ => 0);
        
        foreach(string rep in report){
            //해당 계정을 신고한 id를 ' '로 연결함
            string[] temp = rep.Split(' ');
            idDict[temp[1]] += (temp[0]+' ');
        }
        
        for(int i = 0; i < idDict.Count; i++){
            //현재 계정 신고한 id들을 공백 제거한 문자열 배열로 받아 임시 변수 temp에 담음
            string[] temp = idDict[id_list[i]].Split(' ',StringSplitOptions.RemoveEmptyEntries);
            //해당 계정 신고한 id 수가 정지 기준 횟수 이상이면 신고한 계정의 값 1 증가시킴
            if(temp.Length>=k){
                foreach(string id in temp){
                    reportDict[id]++;
                }
            }
        }
        //answer에 계정별 처리 메일 받은 횟수 출력
        for(int i = 0; i < reportDict.Count; i++){
            answer[i] = reportDict[id_list[i]];
        }
        return answer;
    }
}