using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lok.Tools
{
    public static class Test
    { 
        public static void Index()
        {
            
        }

        public static List<int> GetList(int length)
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < length; i++)
            {
                myList.Add(i);
            }
            return myList;
        }
    }

}