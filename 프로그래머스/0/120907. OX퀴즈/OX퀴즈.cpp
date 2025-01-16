#include <string>
#include <vector>
#include <iostream>

using namespace std;

vector<string> solution(vector<string> quiz) {
    vector<string> answer;
    vector<string> nums;
    string temp = "";
    int test = 0;
    for (int i = 0; i < quiz.size(); i++) {
        for (int j = 0; j <= quiz[i].length(); j++) {
            if (quiz[i][j] == ' ' || j == quiz[i].length()) {
                if (temp != "=") nums.emplace_back(temp);
                temp = "";
                continue;
            }
            temp += quiz[i][j];
        }
        if(nums[1]=="-") test = stoi(nums[0]) - stoi(nums[2]);
        else test = stoi(nums[0]) + stoi(nums[2]);
        if (test == stoi(nums[3])) answer.emplace_back("O");
        else answer.emplace_back("X");
        nums.clear();
    }
    
    
    return answer;
}