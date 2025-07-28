using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] keyinput, int[] board) {
        int[] answer = {0, 0};
        
        //dictionary를 이용한 좌표값 계산 algorithm
        
        //방향키 별 연산을 담은 배열 선언 및 초기화
        var keyDict = new Dictionary<string, int[]> 
        {
            {"up",new int[]{0,1}},{"down",new int[]{0,-1}},
            {"left",new int[]{-1,0}},{"right",new int[]{1,0}}
        };
        //1. board값을 활용해 x, y축 각각 좌표의 끝점 좌표를 구한다.
        //board의 모든 원소 값은 홀수이다.
        int maxX = board[0]/2;
        int maxY = board[1]/2;
        //2. foreach문을 돌려 keyinput 배열에 저장된 키 입력을 하나씩 처리한다.
        foreach(string arrow in keyinput){
            var move = keyDict[arrow];
            answer[0] = Math.Clamp(answer[0] + move[0], -maxX, maxX);
            answer[1] = Math.Clamp(answer[1] + move[1], -maxY, maxY);
            }
        //3. 출력한다.
        return answer;
    }
}