using System;

public class Solution {
    public int[] solution(string[] keyinput, int[] board) {
        int[] answer = {0, 0};
        //switch문을 이용한 좌표값 계산 algorithm
        
        //1. board값을 활용해 x, y축 각각 좌표의 최댓값/최솟값을 구한다.
        int[] MaxCoord = {board[0]/2, board[1]/2}; //board의 모든 원소 값은 홀수이다.
        //2. for문을 돌려 keyinput 배열에 저장된 키 입력을 하나씩 처리한다.
        foreach(string arrow in keyinput){
            switch(arrow){
                case "left":
                    answer[0]--;
                    if (answer[0] < -MaxCoord[0]) answer[0] = -MaxCoord[0];
                    break;
                case "right":
                    answer[0]++;
                    if (answer[0] > MaxCoord[0]) answer[0] = MaxCoord[0];
                    break;
                case "up":
                    answer[1]++;
                    if (answer[1] > MaxCoord[1]) answer[1] = MaxCoord[1];
                    break;
                case "down":
                    answer[1]--;
                    if (answer[1] < -MaxCoord[1]) answer[1] = -MaxCoord[1];
                    break;
                default:
                    break;
            }
        }
        //3. 출력한다.
        return answer;
    }
}