#include <string>
#include <vector>

using namespace std;
void swap(vector<int> &pair){ //얕은 복사를 진행하여 원본 값이 수정되도록 한다. return값 필요없다.
    int temp = 0;
    if(pair[0] < pair[1]) {
            temp = pair[0];
            pair[0] = pair[1];
            pair[1] = temp;
        }
}

int solution(vector<int> wallet, vector<int> bill) {
    //1. 지폐를 접은 횟수를 저장할 정수 변수 answer를 만들고 0을 저장합니다.
    int answer = 0;
    //2. 반복문을 이용해 bill의 작은 값이 wallet의 작은 값 보다 크거나 
    //bill의 큰 값이 wallet의 큰 값 보다 큰 동안 아래 과정을 반복합니다.
    
    while(bill[1] > wallet[1] || bill[0] > wallet[0]){
        if(bill[0] > bill[1]){ //2-1. bill[0]이 bill[1]보다 크다면
            //bill[0]을 2로 나누고 나머지는 버립니다. (정수/정수이므로 나머지는 버려진다.)
            bill[0]/=2;
        }
        else{ //2-2. 그렇지 않다면, bill[0]을 2로 나누고 나머지는 버립니다.
            bill[1]/=2;
        }
        answer++; //2-3. answer을 1 증가시킵니다.
        swap(wallet);
        swap(bill);
    }
    
    //3. answer을 return합니다.
    return answer;
}