using System;

public class Solution {
    public int[] solution(int[] arr) {
        int[] expArr = {1,2,4,8,16,32,64,128,256,512,1024};
        int len = arr.Length;
        for(int i = 0; i < expArr.Length; i++){
            if(len <= expArr[i]){
                len = expArr[i];
                break;
            }
        }
        int[] answer = new int[len];
        for(int i = 0; i < arr.Length; i++){
            answer[i] = arr[i];
        }
        
        return answer;
    }
}