// ===============================
// AUTHOR       : J.Nigesh
// CREATE DATE  : 4/2/2019
// PURPOSE      : To Compare two lists.
// SPECIAL NOTES: The lists may be primitive or reference type.
// FEATURES     : Checks if the lists are null.
//                Checks the type of the lists.
//                Returns true if both the lists are same in type,count and members.
//                Else throws custom exception based on any one of the above said values mismatch.
// ===============================
// Change History:
//
//==================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class ListsComparer
    {

        public bool CompareGenericLists<T, U>(List<T> list1, List<U> list2)
        {
            try
            {
                

                if (typeof(T).Equals(typeof(U)))
                {
                    //For checking null lists
                    if (list1 == null && list2 == null)
                        return true;
                    if (list1 == null || list2 == null)
                        throw new Exception("One of the Lists is Null");

                    if (list1.Count.Equals(list2.Count))
                    {
                        Type type = typeof(T);
                        
                        //For primitive lists
                        if (type.IsPrimitive)
                        {
                            int flag = 0;

                            for (int i = 0; i < list1.Count; i++)
                            {
                                if (list1.ElementAt(i).Equals(list2.ElementAt(i)))
                                    flag++;
                            }
                            if (flag != list1.Count)
                                throw new Exception("Objects values are not same");

                    }

                        //For Reference List
                        else
                        {
                            for (int i = 0; i < list1.Count; i++)
                            {
                                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                                {
                                    string Object1Value = string.Empty;
                                    string Object2Value = string.Empty;

                                    Object1Value = type.GetProperty(property.Name).GetValue(list1.ElementAt(i)).ToString();
                                    Object2Value = type.GetProperty(property.Name).GetValue(list2.ElementAt(i)).ToString();

                                    if (Object1Value != Object2Value)
                                    {
                                        throw new Exception("Objects values are not same");
                                    }

                                }
                            }
                        }
                    }
                    else
                    throw new Exception("Length of lists is not Same");
                }
                else
                throw new Exception("Different type of lists");
            }
            catch(Exception ex)
            {
                throw ex;
            }
                return true; 
        }
}

