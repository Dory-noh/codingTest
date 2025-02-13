using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] order) {
        int answer = 0;
        Stack<int> subStack = new Stack<int> {};
        int idx = 0;
        int pushIdx = 0;
        int wantedBox = order[idx];
        //pushIdx는 order index + 1 보다 작은 값,wantedBox값보다 큰 값을 스택에 넣지 않음.
        while(pushIdx<=wantedBox && pushIdx < order.Length){
            //원하는 물건을 실을 수 있을 때까지 stack에 넣음
            for(pushIdx = pushIdx; pushIdx < wantedBox; pushIdx++){
                subStack.Push(pushIdx+1);
            }
            while(subStack.Count != 0){
                int boxNum = subStack.Pop();
                if(boxNum == wantedBox) {
                    answer++;
                    if(++idx == order.Length) break;
                    wantedBox = order[idx];
                }
                else{
                    //보조 컨테이너 벨트에 원하는 물건이 없을 경우 내부 while문 나감
                    //if(wantedBox != (pushIdx+1)) return answer;
                    subStack.Push(boxNum);
                    break;
                }
            }
            
        }
        
        return answer;
    }
}