#include <string>
#include <vector>
#include <map>
#include <algorithm>

using namespace std;
//value값 비교해서 실패율 내림차순으로 담음
bool cmp (const pair<int,double>& a, const pair<int,double>& b){
    if(a.second == b.second) return a.first < b.first;
    return a.second > b.second;
}
vector<int> solution(int N, vector<int> stages) {
    vector<int> answer;
    //stage와 실패율을 담을 map 선언
    map<int,double> failure;
    //변수 선언 및 초기화
    int totalCount = 0;
    int successCount = 0;
    double failPer = 0;
    
    for(int stage = 1; stage <= N; stage++){
        totalCount = 0;
        successCount = 0;
        for(int i = 0; i < stages.size(); i++) {
            if(stage <= stages[i]) totalCount++;
            if(stage < stages[i]) successCount++;
        }
        //스테이지에 도달한 유저가 없는 경우 해당 스테이지 실패율 0이다. float형 변수 failPer에 현재 스테이지 실패율 담음.
        failPer = totalCount != 0 ? (1- ((double)successCount/totalCount)) : 0;
        //map에 현재 스테이지와 현재 스테이지 실패율을 담음 
        failure.insert({stage, failPer});
    }
    
    //value에 대한 정렬 진행
    vector<pair<int,double>> vec(failure.begin(), failure.end());
    sort(vec.begin(), vec.end(), cmp);
    
    for(int i = 0; i < vec.size(); i++) answer.push_back(vec[i].first);
    return answer;
}
