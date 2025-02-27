using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[,] lines) { //좌표의 값이 정수인 두 점으로 구성된 선분들
        int answer = 0;
        //길이가 1인 선분을 이루는 두 점의 좌표값을 Key값으로 받기 위한 Dictionary 선언 및 초기화
        Dictionary<string, bool> linesDict = new Dictionary<string, bool> {};
        //선분의 수만큼, 반복문을 돌린다. 
        for(int i = 0; i < lines.GetLength(0); i++){
            //선분의 길이만큼 반복문을 돌린다.
            for(int j = lines[i,0]; j < lines[i,1]; j++){
                //길이가 1인 선분을 이루는 두 점의 좌표값을 나열한 문자열 값을 변수 line에 담음
                string line = j.ToString() + (j+1).ToString();
                //해당 line(선분을 길이가 1로 나눈 것 중 일부)이 딕셔너리에 이미 존재할 때
                if(linesDict.ContainsKey(line)) {
                    //겹친 선분이 아직 없는 경우 answer를 1 증가시키고 해당 line의 value값을 true로 바꾼다.
                     if(linesDict[line] == false){
                        answer++;
                        linesDict[line] = true;
                    }
                    //이미 다른 선분과 겹친 부분임을 체크한 경우, 다음 부분 체크로 넘어간다.
                    else{
                        continue;
                    }
                }
                else{
                    //딕셔너리에 해당 line이 존재하지 않는 경우 딕셔너리에 넣는다. value값은 false로 한다.
                   linesDict.Add(line, false);
                }
            }
        }
        return answer;
    }
}