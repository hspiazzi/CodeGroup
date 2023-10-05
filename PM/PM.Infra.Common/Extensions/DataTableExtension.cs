using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PM.Infra.Common.Extensions
{
    public static class DataTableExtensions
    {
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> types;

        static DataTableExtensions()
        {
            types = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
        }

        public static List<T> ToList<T>(this DataTable dataTable) where T : class
        {
            if (!types.ContainsKey(typeof(T)))
            {
                types.Add(typeof(T), typeof(T).GetProperties().ToDictionary(x =>
                {
                    var column = x.GetCustomAttribute(typeof(ColumnAttribute)) as ColumnAttribute;
                    return column == null ? x.Name : column.Name;
                }, x => x));
            }

            var list = new List<T>();
            var columns = dataTable.Columns.Cast<DataColumn>();
            var props =
                from prop in types[typeof(T)]
                join column in columns on prop.Key equals column.ColumnName
                select new
                {
                    PropertyInfo = prop.Value,
                    Column = column
                };

            foreach (var row in dataTable.Rows.Cast<DataRow>())
            {
                var item = Activator.CreateInstance<T>() as T;
                foreach (var prop in props)
                {
                    var value = row[prop.Column.ColumnName];
                    if (value != DBNull.Value)
                        prop.PropertyInfo.SetValue(item, value);
                }
                list.Add(item);
            }
            return list;
        }

        public static List<dynamic> ToList(this DataTable dataTable)
        {
            var list = new List<dynamic>();
            var columns = dataTable.Columns.Cast<DataColumn>();

            foreach (var row in dataTable.Rows.Cast<DataRow>())
            {
                var item = new ExpandoObject() as IDictionary<string, object>;
                foreach (var column in columns)
                {
                    var value = row[column.ColumnName];
                    item.Add(column.ColumnName, value != DBNull.Value ? value : null);
                }
                list.Add(item);
            }
            return list;
        }

        public static T ConvertToObject<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static string ToCSV(this DataTable table)
        {
            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
                }
            }

            return result.ToString();
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
