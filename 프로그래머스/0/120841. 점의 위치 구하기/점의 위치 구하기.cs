using System;

public class Solution {
    public int solution(int[] dot) {
        int answer = dot[0] > 0 ? (dot[1] > 0 ? 1 : 4) : (dot[1] > 0 ? 2 : 3);
        return answer;
    }
}