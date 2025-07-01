using System;
using System.Linq;

public class Solution {
    public int solution(string[] s1, string[] s2) {
        return s1.Count(x=>s2.Contains(x));
    }
}