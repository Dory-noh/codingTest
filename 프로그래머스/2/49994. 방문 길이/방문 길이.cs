using System;
using System.Collections.Generic;

public class Solution {
    
    //두 점의 경로를 string으로 표현해주는 메서드
    //다녀온 경로인지 문자열 리스트 체크하기 위해 사용한다.
    public string GetLine(int[] point1, int[] point2){
        string p1 = point1[0].ToString() + point1[1].ToString();
        string p2 = point2[0].ToString() + point2[1].ToString();
        //두 점의 x값이 같으면 y값이 큰 점의 좌표를 먼저 쓴다.
        if(point1[0] == point2[0]) {
            return point1[1] >= point2[1] ? p1 + p2 : p2 + p1;
        }
        //x값이 같지 않다면, x값이 큰 점의 좌표를 먼저 쓴다.
        return point1[0] > point2[0] ? p1 + p2 : p2 + p1;
    }
    
    public int solution(string dirs) {
        int answer = 0;
        int[] originPos = {0,0};
        List<string> dirLists = new List<string> {};
        //검사
        for(int i = 0; i < dirs.Length; i++){
            char dir = dirs[i];
            //다음 이동할 점의 좌표를 구한다.
            int[] nextPos = {originPos[0],originPos[1]};
            // int[] nextPos = originPos; 이렇게 하면 참조에 의한 전달이 되어 nextPos 수정 시 originPos값이 바뀌어 버린다!
            
            switch(dir){
                case 'L': //x좌표 값 -1
                    nextPos[0]--;
                    break;
                case 'R': //x좌표 값 +1
                    nextPos[0]++;
                    break;
                case 'D': //y좌표 값 -1
                    nextPos[1]--;
                    break;
                case 'U': //y좌표 값 +1
                    nextPos[1]++;
                    break;
            }
            
            //이동한 점의 위치가 좌표 내에 있는 경우
            if(nextPos[0] >= -5 && nextPos[0] <= 5 && nextPos[1] >= -5 && nextPos[1] <= 5){
                //이미 다녀온 경로가 아닌경우 answer를 1 증가한다.
                if(!dirLists.Contains(GetLine(originPos, nextPos))) {
                    answer++;
                    dirLists.Add(GetLine(originPos, nextPos));
                }
                //이동 위치 저장
                originPos = nextPos;
            }
        }
        
        return answer;
    }
}
