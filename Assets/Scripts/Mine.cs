using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MineType
{
    Unknow = 0x0,
    Mine = 0x9,
    Marked = 0xa,
    BadMark = 0xb,
    Empty = 0xc,
    Detonated = 0xd
}

public class Mine : MonoBehaviour
{
    int m_width = 10;
    int m_height = 10;
    int m_numMines = 2;
    int m_badMarkedMines = 0;
    MineType[] m_field;

    void Start()
    {
        m_field = new MineType[m_width * m_height];
    }

    int GetIdx(int x, int y)
    {
        return x + y * m_width;
    }

    int[] GetXY(int idx)
    {
        int x = idx % m_width;
        int y = idx / m_width;
        return new int[]{ x, y };
    }

    MineType GetMine(int x, int y)
    {
        int idx = GetIdx(x, y);
        if (idx >= (m_width*m_height))
        {
            return MineType.Unknow;
        }
        return m_field[idx] & 0f;
    }

    void SetMine(int x, int y, MineType type)
    {
        m_field[GetIdx(x, y)] = type;
    }

    void RandomeMine()
    {
        int minesToSet = m_numMines;
        while (minesToSet > 0)
        {
            int randX = (int)(Random.value * 100000000) % m_width;
            int randY = (int)(Random.value * 100000000) % m_height;
            if (GetMine(randX, randY) != MineType.Mine)
            {
                SetMine(randX, randY, MineType.Mine);
                minesToSet--;
            }
        }
    }

    void RandomeMine2()
    {
        // 

    }

    void Restart()
    {
        RandomeMine();
    }

    int IncrNumber(int x, int y, int num)
    {
        switch(GetMine(x, y))
        {
            case MineType.Mine:
            case MineType.Marked:
            case MineType.Detonated:
                num++;
                break;
        }
        return num;
    }

    int CalcNumber(int x, int y)
    {
        MineType type = GetMine(x, y);
        if (type != MineType.Unknow)
        {
            return (int)type;
        }
        int total = 0;
        if (y - 1 >= 0)
        {
            if (x - 1 >= 0)
            {
                total = IncrNumber(x - 1, y - 1, total);
            }
            total = IncrNumber(x, y - 1, total);
            if (x + 1 < m_width)
            {
                total = IncrNumber(x + 1, y - 1, total);
            }
        }
        if (x - 1 >= 0)
        {
            total = IncrNumber(x - 1, y, total);
        }
        if (x + 1 < m_width)
        {
            total = IncrNumber(x + 1, y, total);
        }
        if (y + 1 < m_height)
        {
            if (x - 1 >= 0)
            {
                total = IncrNumber(x - 1, y + 1, total);
            }
            total = IncrNumber(x, y + 1, total);
            if (x + 1 < m_width)
            {
                total = IncrNumber(x + 1, y + 1, total);
            }
        }
        return total;
    }

    List<int> GetChildren(int x, int y)
    {
        List<int> ret = new List<int>();
        if (y - 1 >= 0)
        {
            if (x - 1 >= 0)
            {
                if (GetMine(x-1, y-1) == MineType.Unknow)
                {
                    ret.Add(GetIdx(x - 1, y - 1));
                }
            }
            if (GetMine(x, y-1) == MineType.Unknow)
            {
                ret.Add(GetIdx(x, y - 1));
            }
            if (x + 1 < m_width)
            {
                if (GetMine(x+1, y-1) == MineType.Unknow)
                {
                    ret.Add(GetIdx(x + 1, y - 1));
                }
            }
        }
        if (x - 1 >= 0)
        {
            if (GetMine(x-1, y) == MineType.Unknow)
            {
                ret.Add(GetIdx(x - 1, y));
            }
        }
        if (x + 1 < m_width)
        {
            if (GetMine(x+1, y) == MineType.Unknow)
            {
                ret.Add(GetIdx(x + 1, y));
            }
        }
        if (y+1 < m_height)
        {
            if (x - 1 >= 0)
            {
                if (GetMine(x-1, y+1) == MineType.Unknow)
                {
                    ret.Add(GetIdx(x - 1, y + 1));
                }
            }
            if (GetMine(x, y+1) == MineType.Unknow)
            {
                ret.Add(GetIdx(x, y + 1));
            }
            if (x+1 < m_width)
            {
                if (GetMine(x+1, y+1) == MineType.Unknow)
                {
                    ret.Add(GetIdx(x + 1, y + 1));
                }
            }
        }
        return ret;
    }

    void Clear(int x, int y)
    {
        Queue<int> idxQueue = new Queue<int>();
        idxQueue.Enqueue(GetIdx(x, y));
        while (idxQueue.Count > 0)
        {
            int[] xy = GetXY(idxQueue.Dequeue());
            int total = CalcNumber(xy[0], xy[1]);
            Debug.Log("total: " + total);
            int type = total;
            if (total == 0)
            {
                type = (int)MineType.Empty;
                foreach (int child in GetChildren(xy[0], xy[1]))
                {
                    if (!idxQueue.Contains(child))
                    {
                        idxQueue.Enqueue(child);
                    }
                }
            }
            SetMine(xy[0], xy[1], (MineType)type);
        }
    }

    void Output()
    {
        Debug.Log("---------------------------");
        for (int i = 0; i < m_height; i++)
        {
            for (int j = 0; j < m_width; j++)
            {
                Debug.Log(OutputFormat((int)GetMine(i, j)));
            }
        }
        Debug.Log("---------------------------");
    }

    string OutputFormat(int type)
    {
        if (type == (int)MineType.Unknow)
        {
            return " - ";
        }
        else if (type == (int)MineType.Empty)
        {
            return "   ";
        }
        else if (type == (int)MineType.Mine)
        {
            return " B ";
        }
        return string.Format(" {0} ", type);
    }
}
