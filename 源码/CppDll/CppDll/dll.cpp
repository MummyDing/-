#include<iostream>
#include<algorithm>
#include<string>
#include<cstring>
#include<queue>
#define N 15
#define Max_Len 100
#define DLL_EXPORT //先定义宏
#include "Dll.h"//这个头文件必须在#define DLL_EXPORT后面
using namespace std;
int n, m, sx, sy, ex, ey, visit[N][N];
int dir[][2] = {
	{ 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }
};
char chess[N][N];
enum TankAcationType
{
	//Move
	MoveStep,
	//Fire Move
	FireOneWall,
	//Fire Fire Move
	FireTwoWall,

	//Dir->Up Move
	ChangeTheDirToUp,
	//Dir->Up Fire
	ChangeToUpFireOne,
	//Dir->Up Fire Fire
	ChangeToUpFireTwo,

	//Dir->Down Fire
	ChangeToDownFireOne,
	//Dir->Down Move
	ChangeTheDirToDown,
	//Dir->Down Fire Fire
	ChangeToDownFireTwo,

	//Dir->Left Move
	ChangeTheDirToLeft,
	//Dir->Left Fire
	ChangeToLeftFireOne,
	//Dir->Left Fire Fire
	ChangeToLeftFireTwo,

	//Dir->Right Move
	ChangeTheDirToRight,
	//Dir->Right Fire
	ChangeToRightFireOne,
	//Dir->Right Fire Fire
	ChangeToRightFireTwo,
	None

} TmpType;
TankAcationType TmpPath[Max_Len];
struct Node{
	int x, y, s,d;
	int step;
	TankAcationType Path[Max_Len];
	friend bool  operator <(Node a, Node b){
		return a.s>b.s;
	}
};
bool ok(int x, int y){
	if (x >= 0 && x<m&&y >= 0 && y<n&&chess[x][y] != 'R'&&chess[x][y] != '#')
		return true;
	return false;
}

extern "C"
{

	DECLDIR int bfs( char  * Map,TankAcationType  * ActionPath,int &Count){
		m = 15;
		n = 15;
		for (int i = 0; i < 15; i++)
		for (int j = 0; j < 15; j++)
			chess[i][j] = '#';
		for (int i = 0; i < 12;i++)
		for (int j = 0; j < 11; j++)
			chess[i][j] = '.';
		for (int i = 0; i<n; i++)
		for (int j = 0; j < m; j++){
			if (Map[i*m + j] == '#'&&chess[i][j] == '.')continue;
			chess[i][j] = Map[i*m + j];
		}
		for (int i = 0; i<m; i++)
		for (int j = 0; j<n; j++){
			if (chess[i][j] == 'T'){
				sx = i; sy = j;
			   chess[i][j] = 'R';
			}
			else if (chess[i][j] == 'X'){
				ex = i; ey = j;
				chess[i][j] = '.';
			}
		}

		priority_queue<Node> q;
		memset(visit, -1, sizeof(visit));
		visit[sx][sy] = 0;
		Node head = { sx, sy, 0 ,1,0};
		head.d = 1;
		q.push(head);
		while (!q.empty())
		{
			Node f = q.top();
			q.pop();
			if (f.x == ex&&f.y == ey){
				for (int i = 0; i < f.step; i++)
					ActionPath[i] = f.Path[i];
				Count =  f.step;
				return f.s;
			}
			for (int i = 0; i<4; i++){
				int dx = f.x + dir[i][0], dy = f.y + dir[i][1];
				if (ok(dx, dy) && visit[dx][dy]){
					visit[dx][dy] = 0;
					int temp = 0;
					if (chess[dx][dy] == 'S'){
						temp = 3;
						if (f.d==i)
						TmpType = FireTwoWall;
						else {
							temp++;
							switch (i)
							{
							case 0:
								TmpType = ChangeToDownFireTwo;
								break;
							case 1:
								TmpType = ChangeToUpFireTwo;
								break;
							case 2:
								TmpType = ChangeToRightFireTwo;
								break;
							case 3:
								TmpType = ChangeToLeftFireTwo;
								break;
							}
						}
					}
					else if (chess[dx][dy] == 'B'){
						temp = 2;
						if(f.d==i)TmpType = FireOneWall;
						else {
							temp++;
							switch (i)
							{
							case 0:
								TmpType = ChangeToDownFireOne;
								break;
							case 1:
								TmpType = ChangeToUpFireOne;
								break;
							case 2:
								TmpType = ChangeToRightFireOne;
								break;
							case 3:
								TmpType = ChangeToLeftFireOne;
								break;
							}
						}
					}
					else if (chess[dx][dy] == '.') {
						temp = 1;
						if(f.d==i)TmpType = MoveStep;
						else {
							temp++;
							switch (i)
							{
							case 0:
								TmpType = ChangeTheDirToDown;
								break;
							case 1:
								TmpType = ChangeTheDirToUp;
								break;
							case 2:
								TmpType = ChangeTheDirToRight;
								break;
							case 3:
								TmpType = ChangeTheDirToLeft;
								break;
							}
						}
					}
					for (int k = 0; k < f.step; k++)
						TmpPath[k] = f.Path[k];
					TmpPath[f.step] = TmpType;
					Node tmp = { dx, dy, f.s + temp};
					for (int k = 0; k <= f.step; k++)
					 tmp.Path[k] = TmpPath[k];
					tmp.step = f.step + 1;
					tmp.d = i;
					q.push(tmp);
				}
			}
		}
		return -1;
	}
}
