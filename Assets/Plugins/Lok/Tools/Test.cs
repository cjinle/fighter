using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lok.Tools
{
    public static class Test
    { 
        public static void Index()
        {
            Stack<int> st = new Stack<int>();
            st.Push(1);
            st.Push(1);
            st.Push(1);
            st.Push(1);
            st.Push(1);
            st.Push(1);

            st.Pop();
            st.Pop();
            st.Pop();
            st.Pop();
            st.Pop();
            st.Pop();
            if (st.Count > 0)
            {

            }
        }
    }

}