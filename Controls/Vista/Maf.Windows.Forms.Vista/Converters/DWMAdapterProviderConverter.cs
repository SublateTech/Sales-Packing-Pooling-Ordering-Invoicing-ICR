using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Windows.Forms;
using Maf.Windows.Forms.DWM;

namespace Maf.ComponentModel
{
    public class DWMAdapterProviderConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType== typeof(InstanceDescriptor)) {
                MessageBox.Show("CanConvertTo(InstanceDescriptor)");
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)) {
                ConstructorInfo ci = typeof(DWMAdapterProvider).GetConstructor(new Type[] { typeof(ContainerControl) });

                return new InstanceDescriptor(ci, null, false);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
