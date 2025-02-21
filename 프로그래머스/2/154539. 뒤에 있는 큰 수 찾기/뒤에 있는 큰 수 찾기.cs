using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer = new int[numbers.Length];
        Stack<int[]> numStack = new Stack<int[]> {};
        int idx = 0;
        int largeNum = 0;
        numStack.Push(new int[] {numbers[idx], idx++});
        do{
            //스택 최상단 값을 temp에 담음
            int[] temp = numStack.Pop();
            //temp값이 다음 인덱스 값보다 작으면 (뒷 큰수 찾음)
            if(temp[0] < numbers[idx]) {
                largeNum = numbers[idx];
                answer[temp[1]] = largeNum;
                //스택에 쌓여있던 친구들에게도 해당 값이 뒷 큰수인지 체크해 줌.
                 while(numStack.Count != 0){
                    int[] temp3 = numStack.Pop();
                    if(temp3[0] < largeNum){
                        answer[temp3[1]] = largeNum;
                    }
                    else {
                        numStack.Push(temp3);
                        break;
                    }
                }
            }
            else{
                numStack.Push(temp);
            }
            numStack.Push(new int[] {numbers[idx], idx++});
            //뒷 큰수를 찾지 못한 경우, 해당 numbers 인덱스의 answer값을 -1로 처리한다.
            if(idx >= numbers.Length){
                while(numStack.Count != 0){
                    int[] temp2 = numStack.Pop();
                    answer[temp2[1]] = -1;
                }
            }
        }while(numStack.Count != 0);
        return answer;
    }
}