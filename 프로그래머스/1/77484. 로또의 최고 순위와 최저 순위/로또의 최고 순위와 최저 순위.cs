using System;
using System.Linq;

public class Solution {
    public int[] solution(int[] lottos, int[] win_nums) {
        int[] answer = new int[2];
        int count = 0;
        int minCount = 0, maxCount = 0;
        //로또의 최저 순위 -> 배열 lottos 중 win_nums와 일치하는 값의 개수에 대한 순위 반환
        //로또의 최고 순위 -> win_nums와 일치하는 lottos 원소의 개수 + 0의 개수에 대한 순위 반환
        for(int i = 0; i < win_nums.Length; i++){
            if(Array.Exists(lottos,x=>x == win_nums[i])) count++;
        }
        //lottos에 있는 값이 0인 요소의 개수를 zeroCount라는 정수형 변수에 저장
        int zeroCount = lottos.Where(x=>x==0).Count();
        
        maxCount = (count+zeroCount);
        minCount = count;
        //일치 번호가 2 미만일 경우 6등이다.
        answer[0] = maxCount >= 2 ? 7 - maxCount : 6;
        answer[1] = minCount >= 2 ? 7 - minCount : 6;
        return answer;
    }
}