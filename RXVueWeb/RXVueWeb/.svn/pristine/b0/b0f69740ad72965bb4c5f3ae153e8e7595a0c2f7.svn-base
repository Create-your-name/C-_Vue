namespace webapi.Util
{
    public class BeanUtil
    {

        public static int[] ForeachClassProperties<T>(T model, String[] Pro)
        {

            int[] result = { 0, 0, 0, 0 };
            Type t = model.GetType();
            var PropertyList = t.GetProperties();
            foreach (var item in PropertyList)
            {
                string name = item.Name;
                if (Array.IndexOf(Pro, name) != -1)
                {
                    object value = item.GetValue(model, null);
                    if (value != null)
                    {
                        int a = Convert.ToInt32(value);
                        result[a - 1]++;
                    }
                }

            }
            return result;
        }


    }
}
