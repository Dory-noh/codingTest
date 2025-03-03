using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[] babbling) {
        int answer = 0;
        foreach(var word in babbling){
            //딕셔너리 선언 및 초기화
            Dictionary<string, bool> words = new Dictionary<string, bool> {{"aya", false},{"ye",false},{"woo",false},{"ma", false}};
            for(int i = 0; i <= word.Length - 2;){
                //현재 인덱스에서 시작하여 문자 2개를 붙였을 때 만들어지는 문자열이 딕셔너리 words에 있는지 확인한다.
                string tempWord = word.Substring(i, 2);
                //words에 있는 경우, 이미 발음된 단어인지 판단한다.
                if(words.ContainsKey(tempWord)){
                    if(words[tempWord] == true){
                        break;
                    }
                    //처음 발음된 문자열인 경우 인덱스 수를 단어의 길이만큼 증가시킨다.
                    else{
                        words[tempWord] = true;
                        i += 2;
                    }
                }
                else{ //(두 문자를 붙여 만든 문자열이 딕셔너리 words에 없는 경우)현 재 인덱스에서 시작하여 문자 3개를 붙였을 때 만들어지는 문자열이 딕셔너리 words에 있는지 확인한다.
                    //현재 인덱스에서부터 세 자리 문자열을 만들 수 없는 경우 반복문 나간다.
                    if(i + 3 > word.Length) break;
                    tempWord = word.Substring(i, 3);
                    if(words.ContainsKey(tempWord)){
                        //이미 발음된 문자열인 경우 반복문 나간다.
                        if(words[tempWord] == true){
                            break;
                        }
                        else{
                            //처음 발음된 문자열인 경우, 발음되었음 표시 후 문자열 길이 만큼 i 증가 시킨다.
                            words[tempWord] = true;
                            i += 3;
                        }
                    }
                    //현재 인덱스에서 2자, 3자 자른 문자열 모두 딕셔너리 words에 키값으로 존재하지 않는 경우 반복문 나가고 다음 word검사한다.
                    else break;
                }
                //현재 word에 대한 문자열 검사를 모두 통과한 경우 answer 값을 1 증가시킨다.
                if(i >= word.Length) answer++;
            }
        }
        return answer;
    }
}