using System;
using System.ComponentModel;
using System.Globalization;
using DigitallyImported.Components;

namespace DigitallyImported.Utilities
{
    // convert from Channel to PremiumChannel
    public class ChannelConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (IChannel))
                return true;
            if (sourceType == typeof (PremiumChannel))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (IChannel))
                return true;
            if (destinationType == typeof (PremiumChannel))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is IChannel)
            {
                return value;
            }
            if (value is PremiumChannel)
            {
                return (PremiumChannel) value;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType)
        {
            if (destinationType == typeof (PremiumChannel))
            {
                return value;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}