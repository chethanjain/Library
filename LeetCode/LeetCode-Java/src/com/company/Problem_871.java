package com.company;

import java.util.PriorityQueue;

public class Problem_871 {
    public static void main(String[] args) {
        Problem_871 obj = new Problem_871();
        int result = obj.minRefuelStops(100, 10, new int[][]{{10, 60}, {20, 30}, {30, 30}, {60, 40}});
    }

    //"https://leetcode.com/problems/minimum-number-of-refueling-stops/description/"
    int minRefuelStops(int target, int fuel, int[][] s) {
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) ->
        {
            return b[1] - a[1];
        });

        int count = 0;
        int d = 0;
        int i = 0;

        while (d < target) {
            while (i < s.length && (fuel - (s[i][0] - d)) >= 0 && d < target) {
                pq.offer(s[i]);
                fuel -= (s[i][0] - d);
                d = s[i][0];
                i++;
            }

            if (d >= target) return count;
            if (i == s.length) {
                while ((fuel + d) < target && pq.size() > 0) {
                    fuel += pq.poll()[1];
                    count++;
                }

                if ((d + fuel) < target) return -1;
                return count;
            }

            if (pq.size() > 0) {
                fuel += pq.poll()[1];
                count++;
            } else {
                return -1;
            }
        }

        return -1;
    }
}
