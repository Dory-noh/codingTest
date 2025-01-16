using System;

public class Solution {
    public string[] solution(string[] quiz) {
        string[] answer = new string[quiz.Length];
        int idx = 0;
        foreach(string items in quiz){
            //공백을 기준으로 문자열을 잘라 배열에 넣는다.
            string[] item = items.Split(' ');
            
            //지역 변수에 값 넣어줌
            int num1 = int.Parse(item[0]);
            int num2 = int.Parse(item[2]);
            //부호가 "-"이면 num2에 -1을 곱한다.
            num2 = item[1] == "-" ? -1 * num2 : num2;
            int result = int.Parse(item[4]);
            
            //<num1 + num2값이 result 값과 같은지 판별한다.>
            //덧셈 연산으로 처리
            answer[idx++] = (num1+num2 == result) ? "O" : "X";
            
        }
        return answer;
    }
}
