using System.Linq;

namespace TheBank.Utilities.TypeExtensions
{
    public static class UpdateObjectExtensions
    {
        public static void UpdateChangedProperties<T>(this T current, T other) where T : ICanBeUpdated
        {
            var propertiesToUpdate =
                typeof(T).GetProperties().Where(prop => !current.PropertiesToIgnore().Contains(prop.Name));

            foreach (var property in propertiesToUpdate)
            {
                if (property.GetValue(current).Equals(property.GetValue(other)))
                    continue;
                property.SetValue(current, property.GetValue(other));
            }
        }
    }
}
