using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string[] solution(string[] quiz) {
        string[] answer = new string[] {};
        List<string> answerList = new List<string> {};
        //공백을 기준으로 문자열을 잘라 리스트에 넣는다.
        foreach(string items in quiz){
            List<string> item = items.Split(' ').ToList();
            //num1 + num2값이 result 값과 같은지 판별한다.
            int num1 = int.Parse(item[0]);
            int num2 = int.Parse(item[2]);
            num2 = item[1] == "-" ? -1 * num2 : num2;
            int result = int.Parse(item[4]);
            answerList.Add(num1+num2 == result ? "O" : "X");
        }
        return answer = answerList.ToArray();
    }
}