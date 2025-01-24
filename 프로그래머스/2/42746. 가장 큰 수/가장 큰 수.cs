using System;
using System.Linq;

public class Solution {
    public string solution(int[] numbers) {
        
        string[] numStr = numbers.Select(x=>x.ToString()).ToArray();
        Array.Sort(numStr, (a,b) => string.Compare(b+a, a+b));
        string answer = string.Join("", numStr);
        answer = answer[0]=='0' ? "0" : answer;
        return answer;
    }
}