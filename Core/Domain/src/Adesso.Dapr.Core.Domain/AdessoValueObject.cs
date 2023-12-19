using System.Reflection;
using Adesso.Dapr.Core.Domain.Abstraction;
using Adesso.Dapr.Core.Domain.Abstraction.Attributes;
using Adesso.Dapr.Core.Domain.Abstraction.Excepotion;

namespace Adesso.Dapr.Core.Domain;

public class AdessoValueObject : IEquatable<AdessoValueObject>
{
    private List<PropertyInfo> _properties;
    private List<FieldInfo> _fields;

    public static bool operator ==(AdessoValueObject obj1, AdessoValueObject obj2)
    {
        if (object.Equals(obj1, null))
        {
            if (object.Equals(obj2, null))
            {
                return true;
            }
            return false;
        }
        return obj1.Equals(obj2);
    }

    public static bool operator !=(AdessoValueObject obj1, AdessoValueObject obj2)
    {
        return !(obj1 == obj2);
    }

    public bool Equals(AdessoValueObject obj)
    {
        return Equals(obj as object);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        return GetProperties().All(p => PropertiesAreEqual(obj, p))
               && GetFields().All(f => FieldsAreEqual(obj, f));
    }

    private bool PropertiesAreEqual(object obj, PropertyInfo p)
    {
        return object.Equals(p.GetValue(this, null), p.GetValue(obj, null));
    }

    private bool FieldsAreEqual(object obj, FieldInfo f)
    {
        return object.Equals(f.GetValue(this), f.GetValue(obj));
    }

    private IEnumerable<PropertyInfo> GetProperties()
    {
        if (this._properties == null)
        {
            this._properties = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute(typeof(AdessoIgnoreMemberAttribute)) == null)
                .ToList();

            // Not available in Core
            // !Attribute.IsDefined(p, typeof(IgnoreMemberAttribute))).ToList();
        }

        return this._properties;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        if (this._fields == null)
        {
            this._fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttribute(typeof(AdessoIgnoreMemberAttribute)) == null)
                .ToList();
        }

        return this._fields;
    }

    public override int GetHashCode()
    {
        unchecked   //allow overflow
        {
            int hash = 17;
            foreach (var prop in GetProperties())
            {
                var value = prop.GetValue(this, null);
                hash = HashValue(hash, value);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = HashValue(hash, value);
            }

            return hash;
        }
    }

    private static int HashValue(int seed, object? value)
    {
        var currentHash = value?.GetHashCode() ?? 0;

        return seed * 23 + currentHash;
    }

    protected static void CheckRule(IAdessoBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new AdessoBusinessRuleValidationException(rule);
        }
    }
}