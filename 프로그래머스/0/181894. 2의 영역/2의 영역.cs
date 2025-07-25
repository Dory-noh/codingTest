using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr) {
        //2의 개수를 샌다
        int n = arr.Count(x=>x==2);
        n = n >= 2 ? 2: n;
        List<int> tempList = new List<int> {};
        int[] answer = new int[] {};
        switch(n){
            //2가 0개일 경우 -> -1 리턴
            case 0 : 
                tempList.Add(-1);
                break;
            //2가 1개일 경우 -> 2 리턴
            case 1:
                tempList.Add(2);
                break;
            case 2:
            //2가 2개 이상일 경우 첫 2 ~ 마지막 2 배열 리턴
                int[] idx = new int[2];
                //해당 배열에서 2가 등장하는 첫 인덱스 찾기
                idx[0] = Array.IndexOf(arr, 2);
                //해당 배열에서 2가 등장하는 마지막 인덱스 찾기
                idx[1] = Array.LastIndexOf(arr,2);
                for(int i = idx[0]; i <= idx[1]; i++){
                    tempList.Add(arr[i]);
                }
                break;
        }
        return answer = tempList.ToArray();
    }
}