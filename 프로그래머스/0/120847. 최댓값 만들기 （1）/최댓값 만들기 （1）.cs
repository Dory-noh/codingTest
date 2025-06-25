using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] numbers) {
        int answer = 0;
        List<int> numList = numbers.ToList();
        numList.Sort();
        answer = numList[numbers.Length-2] * numList[numbers.Length-1];
        return answer;
    }
}