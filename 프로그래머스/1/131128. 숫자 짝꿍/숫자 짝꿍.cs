using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public string solution(string X, string Y) {
        string answer = "";
        bool isZero = true;
        
        //짝꿍 정수를 넣을 리스트 선언 및 초기화
        List<char> commonList = new List<char>() {};
        
        //딕셔너리 선언 및 초기화 - 원하는 값을 찾는 데 효율성을 높이기 위해 딕셔너리를 사용한다.
        Dictionary<char, int> YDict = new Dictionary<char, int>() {};
        
        //YDict는 Y가 가지고 있는 숫자를 Key로, 그 숫자를 가진 개수를 Value로 가진다.
        for(int i = 0; i < Y.Length; i++){
            char ch = Y[i];
            if(YDict.ContainsKey(ch)) YDict[ch]++;
            else YDict.Add(ch,1);
        }
        
        //X에 든 요소들과 Y에 든 요소들 짝꿍 찾기
        for(int i = 0; i < X.Length; i++){
            char num = X[i];
            if(YDict.ContainsKey(num)) {
                if(YDict[num]==0) continue;
                commonList.Add(num);
                YDict[num]--;
                if(isZero == true) isZero = (num == '0'); 
            }
        }
        //공통적인 수가 없다면 -1을 리턴한다.
        if(commonList.Count == 0) return answer = "-1";
        //공통된 수가 모두 0이면 0을 리턴한다.
        if(isZero == true) return answer = "0";
        //위 두 경우가 아니면, 모은 공통 수를 내림차순으로 정리한다.
        commonList = commonList.OrderByDescending(i=>i).ToList();
        //리스트 값을 하나의 문자열로 합친다.
        answer = string.Join("",commonList);
        return answer;
    }
}