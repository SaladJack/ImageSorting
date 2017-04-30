using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVS
{
    public class SortObject
    {
        public double grade;
        public string path;
        public string name;
        
        public SortObject(double grade,string path,string name)
        {
            this.grade = grade;
            this.path = path;
            this.name = name;
        }
    }
    public class sortObjectComparer : IComparer<SortObject>
    {
        public sortObjectComparer() { }
        public int Compare(SortObject s1, SortObject s2)
        {
            return s2.grade.CompareTo(s1.grade);
        }
    }
}
