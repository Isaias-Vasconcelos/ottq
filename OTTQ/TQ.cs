using System.Reflection;

namespace OTTQ
{
    public static class TQ<T>
    {
        public static string SqlCreateTable(T tableObject)
        {
            var type = tableObject.GetType();
            var tableName = type.Name;

            var query = $@"CREATE TABLE IF NOT EXISTS {tableName.ToLower()} (";

            PropertyInfo[] propiedades = type.GetProperties();

            foreach (var prop in propiedades)
            {
                var columnName = prop.Name.ToLower();

                var typeColumn = prop.GetValue(tableObject);

                query += $"{columnName} {typeColumn},";
            }

            query += $"PRIMARY KEY(id));";

            return query ;
        }
    }
}
