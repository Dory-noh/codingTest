using System;

public class Solution {
    //깊이 우선 탐색을 이용해 모든 경우의 수를 살펴 탐험 가능 최대 던전 수 값(cnt)을 얻는다.
    int answer;
    int N;
    int[] visited;
    
    public int solution(int k, int[,] dungeons) {
        //같은 클래스에 있는 다른 메서드에서도 변수 접근 가능하도록 public 사용
        answer = 0;
        //c# 2차원 배열에서 Length값 조회시 행*열 값이 출력된다. 행의 값만 받기 위해 GetLength(0) 사용.
        N = dungeons.GetLength(0);
        visited = new int[N];
        //함수 호출
        dfsDg(k, 0, dungeons);
        return answer;
    }
    public void dfsDg(int k, int cnt, int[,] dungeons){
         //cnt 값이 현재 answer값보다 큰 경우 answer값을 cnt값으로 수정한다.
        answer = answer < cnt ? cnt : answer;
        //모든 던전에 대하여 피로도, 방문 여부 체크한다.
        for(int i = 0; i < N; i++){
            //아직 방문하지 않은 곳이고 현재 피로도 - 소모 피로도의 값이 양수 or 0이면 접근
            if(k >= dungeons[i, 0] && visited[i] == 0){
                visited[i] = 1;
                //재귀
                dfsDg(k-dungeons[i, 1], cnt+1, dungeons);
                //backtracking...
                visited[i] = 0;
            }
            
        }
    }
}