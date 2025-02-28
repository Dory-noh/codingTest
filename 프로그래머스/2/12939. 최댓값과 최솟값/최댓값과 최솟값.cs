using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string solution(string s) {
        string answer = "";
        int temp = 0;
        //Linq 활용
        int[] numArr = s.Split(' ').Select(int.Parse).ToArray();
        answer = numArr.Min().ToString()+" "+numArr.Max().ToString();
        return answer;
    }
}