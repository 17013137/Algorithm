using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Graph
    {
        int[,] adj = new int[6, 6] {
            {0, 1, 0, 1, 0, 0 },
            {1, 0, 1, 1, 0, 0 },
            {0, 1, 0, 0, 0, 0 },
            {1, 1, 0, 0, 1, 0 },
            {0, 0, 0, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 }
        };
        bool[] visited = new bool[6];
        // 1) 우선 now부터 방문하고.
        // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견(미방문) 상태라면 방문한다.
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; // 1) 우선 now부터 방문하고,

            for(int next = 0 ; next < 6; next++)
            {
                if (adj[now, next] == 0) continue; // 연결되어 있지 않으면 스킵
                if (visited[next]) continue; // 이미 방문했으면 스킵.
                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach(int next in adj2[now])
            {
                if (visited[next] == true) continue;
                DFS2(next); 
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for(int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS(now);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.DFS(5);

        }
    }
}
