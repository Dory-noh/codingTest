using System;

public class Solution {
    public int solution(int[,] dots) {
        int answer = 0;
        int[,] points = new int[,] {{0,1,2,3},{0,2,1,3},{0,3,1,2}};
        for(int i = 0; i < points.GetLength(0); i++){
            if((dots[points[i,1],1] - dots[points[i,0],1])*(dots[points[i,3],0] - dots[points[i,2],0])==(dots[points[i,3],1] - dots[points[i,2],1])*(dots[points[i,1],0] - dots[points[i,0],0]))
            {
                answer = 1;
                break;
            }
        }
        return answer;
    }
}