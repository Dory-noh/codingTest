#include <string>
#include <vector>

using namespace std;
vector<int> heap;
void Swap(int i, int j){
    int t = heap[i];
    heap[i] = heap[j];
    heap[j] = t;
}
//트리에 최솟값이 root에 오도록 원소 담음
void Add(int value){
    heap.push_back(value);
    int i = heap.size() - 1;
    while(i > 0){
        int parent = (i-1) / 2;
        if(heap[parent] > heap[i]){
            Swap(parent, i);
            i = parent;
        }
        else{
            break;
        }
    }
}

//최솟값을 제거하고 제일 끝에 있는 원소를 루트로 올린 후 원소 크기 비교를 통해 트리 재정렬함.
int RemoveOne(){
    if(heap.size() == 0) return -999;
    int root = heap[0];
    
    heap[0] = heap[heap.size() - 1];
    heap.erase(heap.end() - 1);
    
    int i = 0;
    int last = heap.size() - 1;
    while(i < last)
    {
        int child = i * 2 + 1;
        
        if(child < last && heap[child] >= heap[child + 1]) child = child + 1;
        
        if(child > last || heap[i] <= heap[child]) break;
        
        Swap(i, child);
        i = child;
    }
    return root;
}

int solution(vector<int> scoville, int K) {
    int answer = 0;
    
    //heap 내부에 최솟값이 root가 되도록 넣음
    for(int i = 0; i < scoville.size(); i++){
        Add(scoville[i]);
    }
    while(true){
        //벡터의 모든 요소가 스코빌 지수 기준치 이상인 경우 반복문을 종료한다.
        if(heap[0] >= K) break;
        
        //더 이상 합칠 수 없는 경우 반복문을 종료한다.
        if(heap.size()==1) return -1;
        
        answer++;
        
        int rootMin = RemoveOne();
        int subMin = RemoveOne();
        
        //scoville에 합친 값 원소 추가
        Add(rootMin+subMin*2);
        
    }
    return answer;
}