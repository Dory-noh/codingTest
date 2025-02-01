using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] id_list, string[] report, int k) {
        int[] answer = new int[id_list.Length];
        
        //신고된 id를 담는 idDict, 
        //신고한 계정 id를 담는 reportDict, Dictionary 선언 및 초기화
        //문자열-user ID를 key로 하여 값을 입력받음
        Dictionary<string, string> idDict = new Dictionary<string, string> {};
        Dictionary<string, int> reportDict = new Dictionary<string, int> {};
        //키-값 초기값으로 생성
        foreach(string id in id_list){
            idDict.Add(id,"");
            reportDict.Add(id,0);
        }
        //중복 신고 제거를 위한 정렬
        Array.Sort(report);
        
        string beforeRept = "";
        foreach(string rep in report){
            //중복 신고 내용이면 건너뜀
            if(beforeRept == rep) continue;
            //해당 계정을 신고한 id를 ' '로 연결함
            string[] temp = rep.Split(' ');
            idDict[temp[1]] += (temp[0]+' ');
            beforeRept = rep;
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