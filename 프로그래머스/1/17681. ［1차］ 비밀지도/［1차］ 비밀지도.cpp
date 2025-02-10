#include <string>
#include <vector>

using namespace std;

vector<string> solution(int n, vector<int> arr1, vector<int> arr2) {
    vector<string> answer;
    for(int i = 0; i < n; i++){
        //두 vector의 현재 인덱스 값을 정수형 변수 temp1, temp2에 각각 담음.
        int temp1 = arr1[i], temp2 = arr2[i];
        //현재 행의 정보값을 임시로 담을 문자열 변수 선언 및 초기화
        string decodingStr = "";
        for(int j = 0; j < n; j++){
            //비트 연산 진행. 삼항 연산자를 이용하여 둘 다 0이면 공백을, 아니면 "#"을 문자열에 담음. 현재 2진 연산이 뒤쪽부터 이루어지기 때문에 최근 연산 값을 문자열 앞에다 연결한다.
            string ch = (temp1%2|temp2%2)==0? " " : "#";
            decodingStr = ch + decodingStr;
            temp1/=2, temp2/=2;
        }
        //answer에 인덱스 순으로 담음
        answer.push_back(decodingStr);
    }
    return answer;
}