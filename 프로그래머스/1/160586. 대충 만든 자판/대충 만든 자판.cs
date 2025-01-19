using System;

public class Solution {
    public int[] solution(string[] keymap, string[] targets) {
        int[] answer = new int[targets.Length];
        //알파벳별 최소 키 입력 수 넣어둘 배열 초기화
        int[] alpha = new int[26];
        Array.Fill(alpha, 99);
        //알파벳별 최소 입력 횟수 저장
        for(int i = 0; i < alpha.Length; i++){
            for(int j = 0; j < keymap.Length; j++){
                int idx = keymap[j].IndexOf(Convert.ToChar('A'+i));
                if(idx >= 0 && idx < alpha[i]) alpha[i] = idx+1;
            }
        }
        
        for(int i = 0; i < targets.Length; i++){
            string target = targets[i];
            //버튼 누른 횟수를 세는 변수
            int count = 0;
            for(int j = 0; j < target.Length; j++){
                int time = alpha[target[j]-'A'];
                //keymap에 없는 알파벳이면 targets의 현재 인덱스 값 -1 입력 후 다음 타겟으로 넘어감
                if(time==99) {
                    answer[i] = -1;
                    break;
                }
                count += time;
            }
            if(answer[i] != -1) answer[i] = count;
        }
        
        return answer;
    }
}