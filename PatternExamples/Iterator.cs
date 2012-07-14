using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PatternExamples
{
    // interface designed for the container.
    public interface IIterable
    {
        IIterator GetIterator();
    }

    // iterator interface
    public interface IIterator
    {
        bool HasNext();
        bool MoveNext();
        Object Current{get;}
        void Reset();
    }

    // the concrete iterator
    public class PhoneContainerIterator: IIterator// IEnumerator
    {
        private PhoneContainter list;
        private int index;

        public PhoneContainerIterator(PhoneContainter alist)
        {
            list = alist;
            index = 0;
        }

        public bool HasNext()
        {
            return index < (list.Count - 1);
        }
        public bool MoveNext()
        {
            if (index < (list.Count - 1))
            {
                index++;
                return true;
            }
            else
                return false;
        }

        public Object Current
        {
            get {
                return list.GetPhoneNameByIndex(index);
            }
        }
            /*
        {
            return list.GetPhoneNameByIndex(index);
        }*/

        public void Reset()
        {
            index = 0;
        }
    }

    // 实现IIterable， 说明这个container是可遍历的
    public class PhoneContainter: IIterable
    {
        private List<string> phoneList = null;

        public int Count
        {
            get { return phoneList.Count; }
            private set{;}
        }

        public string GetPhoneNameByIndex(int index)
        {
            if (index <= phoneList.Count - 1)
            {
                return phoneList[index];
            }
            else
                return null;
        }

        public PhoneContainter()
        { 
            // init the phone list.
            phoneList = new List<string>();
            phoneList.Add("Nokia Lumia800");
            phoneList.Add("Nokia N8");
            phoneList.Add("Nokia N9");
            phoneList.Add("Nokia Lumia900");
            phoneList.Add("Nokia 710");
            phoneList.Add("Nokia PureView 808");
            phoneList.Add("Nokia N97");

        }
        public IIterator GetIterator()
        {
            return new PhoneContainerIterator(this);
        }
    }
}
