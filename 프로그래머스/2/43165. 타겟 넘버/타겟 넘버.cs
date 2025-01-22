using System;

//Depth First Search
public class Solution {
    int answer = 0;
    public int solution(int[] numbers, int target) {
        int depth = 0;
        int num = numbers[0];
        getDfs(numbers, num, depth, target);
        getDfs(numbers, -num, depth, target);
        //재귀 함수 호출
        return answer;
    }
    public void getDfs(int[] numbers, int num, int depth, int target){
        //depth 끝까지 도달했을 때 num값이 target 값과 같으면 answer++;
        if(depth == numbers.Length - 1){
            if(num == target){
                answer++;
            }
            return;
        }
        //아직 depth끝까지 도달하지 않은 경우 다음 depth로 넘어가기
        getDfs(numbers, num + numbers[++depth], depth, target);
        getDfs(numbers, num - numbers[depth], depth, target);
    }
}