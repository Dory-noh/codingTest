#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

int solution(vector<int> nums)
{
    int answer = 0;
    int len = nums.size();
    //선택할 수 있는 최대 폰켓몬 수 : nums.size() / 2
    //중복으로 인하여 선택할 수 있는 가짓 수는 최대 선택 가능한 폰켓몬 수보다 적을 수 있다.
    
    //중복 제거 nums
    sort(nums.begin(), nums.end());
    nums.erase(unique(nums.begin(), nums.end()),nums.end());
    //중복을 제거한 nums의 길이가 최대 선택 가능한 폰켓몬 수보다 적을 경우
    //중복 제거한 nums의 길이가 answer값이다.
    answer = len/2 >= nums.size() ? nums.size() : len/2;
    return answer;
}