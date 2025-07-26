using System;

public class Solution {
    public int solution(int[] arr) {
        int answer = 0;
        int sameCount = 0;
        while(sameCount != arr.Length){
            answer++;
            sameCount = 0;
            for(int i = 0; i < arr.Length; i++){
                int tempNum = arr[i];
                if(tempNum >= 50 && tempNum % 2 == 0) tempNum/=2;
                else if(tempNum < 50 && tempNum % 2 ==1) tempNum = tempNum * 2 + 1;
                if(tempNum == arr[i]) sameCount++;
                arr[i] = tempNum;
            }
            
        }
        return --answer;
    }
}