#include <string>
#include <vector>

using namespace std;

string solution(string new_id) {
    string answer = "";
    for(int i = 0; i < new_id.size(); i++){
        //총 7단계 검증에 통과한 문자만 answer문자열에 연결한다.
        char temp = new_id[i];
        
        //1단계 : new_id의 모든 대문자를 대응되는 소문자로 치환하기
        if(temp >= 'A' && temp <= 'Z'){
            temp += 32;
        }
        //2단계 : new_id에서 알파벳 소문자, 숫자, 빼기(-), 밑줄(_), 마침표(.)를 제외한 모든 문자를 제거하기
        if(!(temp >= 'a' && temp <='z') && !(temp >= '0' && temp <= '9') && temp != '-' && temp != '_' && temp != '.') continue;
        
        //3단계 : new_id에서 마침표(.)가 2번 이상 연속된 부분을 하나의 마침표(.)로 치환하기
        if(answer.size() != 0 && answer[answer.size()-1] == '.' && temp == '.') continue;
        
        //4단계 - 1 : new_id에서 마침표(.)가 처음에 위치한다면 제거하기
        if(answer.size() == 0 && temp == '.') continue;
        
        //1 ~ 4단계 조건에 맞게 수정된 temp값을 answer에 담음
        answer += temp;
    }
    //4단계 - 2 : answer에서 마침표(.)가 문자열 끝에 위치한다면 제거하기
    if(answer[answer.size() - 1] == '.') answer = answer.substr(0,answer.size()-1);
    
    //5단계 : answer가 빈 문자열이라면, answer에 "a"를 대입하기
    if(answer.size() == 0) answer = "a";
    
    //6단계 : answer가 16자 이상이면, new_id의 첫 15개의 문자를 제외한 나머지 문자들을 모두 제거하기
    if(answer.size() >= 16) answer = answer.substr(0, 15);
    //만약 제거 후 마침표(.)가 new_id의 끝에 위치한다면 끝에 위치한 마침표(.) 문자를 제거하기
    if(answer[answer.size() - 1] == '.') answer = answer.substr(0,answer.size()-1);
    
    //7단계 : answer의 길이가 2자 이하라면, answer의 마지막 문자를 new_id의 길이가 3이 될 때까지 반복해서 끝에 붙이기
    for(int i = answer.size(); i < 3; i++) answer += (answer[answer.size()-1]); 
    
    return answer;
}