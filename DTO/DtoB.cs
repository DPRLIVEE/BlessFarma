using System;
using System.ComponentModel;
using System.Reflection;

namespace DTO
{
    [Serializable]
    public class DtoB : ClassResultV, ICloneable
    {
        [Browsable(false)]
        public string MsjError { get; set; }

        [Browsable(false)]
        public DtoB Error(string msj)
        {
            MsjError = msj;
            return this;
        }

        public String Criterio { get; set; }
        public String Msj { get; set; }

        #region Miembros de ICloneable

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}

public static class Extensions
{
    /// <summary>
    ///     Perform a deep Copy of the object.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="item"></param>
    /// <returns>The copied object.</returns>
    public static T Clone<T>(this T item) where T : ICloneable
    {
        return (T)item.Clone();
    }

    public static bool IsEqualsTo<T>(this T dtoAnt, T dtoNew)
    {
        try
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanRead) continue;
                if (property.GetValue(dtoAnt, null) == null || property.GetValue(dtoNew, null) == null) continue;
                if (property.GetValue(dtoAnt, null).ToString() == property.GetValue(dtoNew, null).ToString()) continue;
                return false;
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
