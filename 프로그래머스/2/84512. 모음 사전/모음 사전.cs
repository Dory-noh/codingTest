using System;

public class Solution {
    public int solution(string word) {
        string vowel = "AEIOU";
        int[] countArr = new int[5] {781, 156, 31, 6, 1};
        int answer = 0;
        for(int i = 0 ; i < word.Length; i++){
            int idx = vowel.IndexOf(word[i]);
            answer += (countArr[i]*idx+1);
        }
        return answer;
    }
}