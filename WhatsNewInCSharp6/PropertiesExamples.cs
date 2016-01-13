namespace WhatsNewInCSharp6
{
    public class OldDefaultValues
    {
        // Too much code 
        public OldDefaultValues()
        {
            PropertyWithDefaultValue = "Default value";
        }

        public string PropertyWithDefaultValue { get; set; }
    }

    /// <summary>
    /// - Initializers for auto-properties
    /// </summary>
    public class NewDefaultValues
    {
        public string PropertyWithDefaultValue { get; set; } = "Default value";
    }

    public class OldImmutableClass
    {
        // Redundant backing field
        private readonly string readOnlyBackingField;

        public OldImmutableClass(string theValue)
        {
            readOnlyBackingField = theValue;
            PseudoImmutableProperty = "Default value";
        }

        // Too much code again
        // ReSharper disable once ConvertToAutoProperty
        // ReSharper disable once ConvertPropertyToExpressionBody
        public string ReadOnlyProperty { get { return readOnlyBackingField;  } }

        // Not really immutable
        public string PseudoImmutableProperty { get; private set; }

        public override string ToString()
        {
            PseudoImmutableProperty = "Not really immutable";
            return ReadOnlyProperty + " " + PseudoImmutableProperty;
        }
    }

    /// <summary>
    /// - Getter-only auto-properties
    /// </summary>
    public class ProperImmutableClass
    {
        public ProperImmutableClass(string theValue)
        {
            ReadOnlyProperty = theValue;
        }

        // Readonly backing field added by the compiler
        public string ReadOnlyProperty { get; }

        // Readonly properties can also have default values,
        // but this value can still be overridden in a constructor
        public string ReadOnlyPropertyWithDefaultValue { get; } = "Default value";

        public override string ToString()
        {
            return ReadOnlyProperty + " " + ReadOnlyPropertyWithDefaultValue;
        }
    }
}