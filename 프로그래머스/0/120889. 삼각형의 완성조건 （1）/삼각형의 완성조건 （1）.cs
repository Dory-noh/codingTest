using System;

public class Solution {
    public int solution(int[] sides) {
        int answer = 0;
        int max = sides[0] > sides[1] ? (sides[0] > sides[2] ? 0 : 2) : (sides[1] > sides[2] ? 1 : 2);
        int a = 0,b = 0,c = 0;
        switch(max){
            case 0 : 
                c = sides[0];
                a = sides[1];
                b = sides[2];
                break;
            case 1 :
                c = sides[1];
                a = sides[0];
                b = sides[2];
                break;
            case 2 :
                c = sides[2];
                a = sides[0];
                b = sides[1];
                break;
                default :
                break;
        }
        return answer = c < (a+b) ? 1 : 2;
    }
}