using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] arr) {
        //2의 개수를 샌다
        int n = arr.Count(x=>x==2);
        n = n >= 2 ? 2: n;
        //IndexOf 사용을 위해 정수형 배열을 문자형 배열로 전환하였다.
        string strArr = String.Join("/", arr);
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
                idx[0] = strArr.IndexOf('2');
                idx[1] = strArr.LastIndexOf('2');
                for(int i = idx[0]; i <= idx[1]; i++){
                    if(strArr[i]=='/') continue;
                    string tempStr = strArr[i]+"";
                    if(strArr[i]=='1' && i!=idx[1] && strArr[i+1] == '0') {tempStr += strArr[i+1]+""; i++;
                                                                          }
                    tempList.Add(Int32.Parse(tempStr));
                }
                break;
        }
        return answer = tempList.ToArray();
    }
}