using System;

public class Solution {
    public void CheckWord(){
        
    }
    public int solution(string[] babbling) {
        int answer = 0;
        string tempWord = "";
        string[] words = {"aya", "ye", "woo", "ma"};
        foreach(var word in babbling){
            string tempStr = "";
            string recentWord = "";
            for(int i = 0; i < word.Length; i++){
                //현재 인덱스에서 발음할 수 있는 단어의 최소 길이인 2, 최대 길이 3까지 tempWord에 담아 비교해본다.
                if(i+2 > word.Length) break;
                tempWord = word.Substring(i,2);
                if(Array.Exists(words, x => x == tempWord)){
                    if(recentWord == tempWord) break;
                    i = i + 1;
                    tempStr += tempWord;
                    recentWord = tempWord;
                }
                else{
                    if(i+3 > word.Length) break;
                    tempWord = word.Substring(i,3);
                    if(Array.Exists(words, x => x == tempWord)){
                        if(recentWord == tempWord) break;
                        i = i + 2;
                        tempStr += tempWord;
                        recentWord = tempWord;
                    }
                    else{
                        break;
                    }
                }
            }
            if(tempStr.Length == word.Length) answer++;
        }
        return answer;
    }
}