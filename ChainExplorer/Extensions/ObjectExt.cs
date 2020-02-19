using System;

namespace ChainExplorer.Extensions
{
    class ObjectExt
    {
        public static T Clone<T>(T original)
        {
            var newObject = (T)Activator.CreateInstance(original.GetType());

            foreach (var originalProp in original.GetType().GetProperties())
            {
                originalProp.SetValue(newObject, originalProp.GetValue(original));
            }

            return newObject;
        }
    }
}
