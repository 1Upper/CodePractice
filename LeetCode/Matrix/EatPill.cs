/*
 http://www.jiuzhang.com/qa/2255/
 Google onsite 面经 吃药的概率
有一罐药片，每天你可以从其中拿一片，如果拿到一整片药，
你只能吃一半，把另一半放回去，如果拿到半片药就可以直接吃。假设一开始药罐子里有n片完整的药，求第k天拿到一整片药的概率。

Eat half Pill per day, so it is total 2*N days to eat N pills

数列 W:  第Kth 天，拿到一整片药的路径										
	1	2	3	4	5	6	7	8	9	10
1	1	0	0	0	0	0	0	0	0	0
2	1	1	1	0	0	0	0	0	0	0
3	1	2	3	3	3	0	0	0	0	0
4	1	3	6	9	12	12	12	0	0	0
5	1	4	10	19	31	43	55	55	55	0
										
数列 H: 第Kth 天，拿到半片药的路径										
	1	2	3	4	5	6	7	8	9	10
1	0	1	0	0	0	0	0	0	0	0
2	0	1	1	1	0	0	0	0	0	0
3	0	1	2	3	3	0	0	0	0	0
4	0	1	3	6	9	9	9	0	0	0
5	0	1	4	10	19	28	37	37	37	0

P[2,2] = W[2,2] / (W[2,2] + H[2,2]) = 0.5  

2片药，第二天只剩1个whole, 1个half，所以概率是0.5


问题延伸：连续K天拿到一整片药的路径数目					
						
	        1	2	3	4	5	6  Kth  - The Kth selection
        1	1	0	0	0	0	0
        2	1	1	0	0	0	0
        3	1	2	2	0	0	0
        4	1	3	5	5	0	0
        5	1	4	9	14	14	0
        6	1	5	14	28	42	42
        Nth 
The Nth Pill
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class EatPill
    {
        // TBD
    }
}
