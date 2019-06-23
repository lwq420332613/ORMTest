using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LWQ.Framework
{
    public static class DbAttributeExtend
    {
        public static string GetMappingName<T>(this T t) where T:MemberInfo
        {
            if (t.IsDefined(typeof(BaseMappingAttribute), true))
            {
                BaseMappingAttribute attribute = (BaseMappingAttribute)t.GetCustomAttribute(typeof(BaseMappingAttribute), true);
                return attribute.GetName();
            }
            return t.Name;
        }

        ///// <summary>
        ///// 获取方法名映射
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string GetMappingName(this Type type)
        //{
        //    if (type.IsDefined(typeof(TableAttribute), true))
        //    {
        //        TableAttribute attribute = (TableAttribute) type.GetCustomAttribute(typeof(TableAttribute), true);
        //        return attribute.GetName();
        //    }
        //    return type.Name;
        //}

        ///// <summary>
        ///// 获取属性的映射
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string GetMappingName(this PropertyInfo type)
        //{
        //    if (type.IsDefined(typeof(ColumnAttribute), true))
        //    {
        //        ColumnAttribute attribute = (ColumnAttribute)type.GetCustomAttribute(typeof(ColumnAttribute), true);
        //        return attribute.GetName();
        //    }
        //    return type.Name;
        //}
    }
}
