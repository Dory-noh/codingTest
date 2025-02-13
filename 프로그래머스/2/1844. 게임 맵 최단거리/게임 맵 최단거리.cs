using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    public int solution(int[,] maps) {
        int answer = 0;
        int n = maps.GetLength(0);
        int m = maps.GetLength(1);
        int MaxCount = maps.Cast<int>().Count(x => x == 1);
        Queue<int[]> queue = new Queue<int[]> {};
                        //(늦게 쌓인 것에 먼저 접근) 좌, 상, 우, 하
        int[,] dirArr = {{-1, 0}, {0, -1}, {1, 0}, {0, 1}};
        int[,] mapCount = new int[n,m];
        int[] curPos = {0, 0};
        int[] targetPos = {n-1, m-1};
        
        mapCount[0,0] = 1;
        queue.Enqueue(new int[] {0,0});
        maps[0,0] = 0;
        while(queue.Count != 0){
            curPos = queue.Dequeue();
            if(curPos[0] == targetPos[0] && curPos[1] == targetPos[1]) {
                return mapCount[curPos[0], curPos[1]];
            }
            for(int j = 0; j < 4; j++){
                int x = curPos[0]+dirArr[j,0], y = curPos[1] + dirArr[j,1];
                if((x < n && x >= 0) && (y < m && y >= 0)){
                    if(maps[x, y] == 1){
                        maps[x, y] = 0;
                        mapCount[x, y] = mapCount[curPos[0], curPos[1]]+1;
                        queue.Enqueue(new int[] {x,y});
                    }
                }
            }
        }
        return -1;
    }
}