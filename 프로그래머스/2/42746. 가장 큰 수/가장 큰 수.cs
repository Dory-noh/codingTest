using System;
using System.Linq;

public class Solution {
    public string solution(int[] numbers) {
        
        string[] numStr = numbers.Select(x=>x.ToString()).ToArray();
        //문자열 두 개를 비교해서 순서를 ab / ba로 배치했을 때, b+a가 a+b보다 크면 b를 먼저 배치하고 a를 나중에 배치한다.
        Array.Sort(numStr, (a,b) => string.Compare(b+a, a+b));
        string answer = string.Join("", numStr); 
        //numbers의 모든 원소가 0이면 answer의 값은 "0"이다.
        answer = answer[0]=='0' ? "0" : answer;
        return answer;
    }
}