using System;

public class Solution {
    public int solution(string skill, string[] skill_trees) {
        int answer = 0;
        string skillStr = "";
        
        foreach(string skillTree in skill_trees){
            skillStr = "";
            //스킬트리에서 선행 스킬에 존재하는 스킬들 진행 순서대로 문자열에 담음
            for(int i = 0; i < skillTree.Length; i++){
                if(skill.IndexOf(skillTree[i]) >= 0) {
                    skillStr += skillTree[i];
                }
            }
            //선행 스킬을 하나도 배우지 않는 경우도 있다.
            //빈 문자열이 아니고 선행 스킬 순서대로 진행이 되었으면 answer++
            if(skill.IndexOf(skillStr)==0) answer++;
            //Console.WriteLine(skillTree+":"+skillStr+" "+skill.IndexOf(skillStr));
        }
        return answer;
    }
}