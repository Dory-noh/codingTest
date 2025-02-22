using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        int len1 = arr1.GetLength(0); //arr1의 행 개수
        int len2 = arr2.GetLength(1); //arr2의 열 개수
        int len3 = arr1.GetLength(1); //arr1의 열 개수이자 arr2의 행 개수
        //arr1, arr2의 행렬의 곱 결과인 answer의 크기는 arr1의 행 개수 * arr2의 열 개수 이다.
        int[,] answer = new int[len1, len2];
        
        for(int i = 0; i < len1; i++){
            for(int j = 0; j < len2; j++){
                int sum = 0;
                //행렬의 곱 연산 진행
                for(int num1 = 0; num1 < len3; num1++){
                    //arr1의 열의 개수와 arr2의 행의 개수는 같다.
                        sum += arr1[i,num1] * arr2[num1,j];
                }
                //연산 결과를 담음
                answer[i,j] = sum;
            }
        }
        return answer;
    }
}