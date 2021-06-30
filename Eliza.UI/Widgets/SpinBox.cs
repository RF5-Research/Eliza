using Eliza.UI.Helpers;
using Eto.Forms;
using System;

namespace Eliza.UI.Widgets
{

    class SpinBox : GenericWidget
    {
        public NumericStepper numericStepper = new NumericStepper();

        public SpinBox(Ref<byte> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = byte.MinValue;
            //numericStepper.MaxValue = byte.MaxValue;
            Setup();
        }

        public SpinBox(Ref<ushort> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = ushort.MinValue;
            //numericStepper.MaxValue = ushort.MaxValue;
            Setup();
        }

        public SpinBox(Ref<uint> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = uint.MinValue;
            //numericStepper.MaxValue = uint.MaxValue;
            Setup();
        }

        public SpinBox(Ref<ulong> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = ulong.MinValue;
            //numericStepper.MaxValue = ulong.MaxValue;
            Setup();
        }

        public SpinBox(Ref<sbyte> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = sbyte.MinValue;
            //numericStepper.MaxValue = sbyte.MaxValue;
            Setup();
        }

        public SpinBox(Ref<short> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = short.MinValue;
            //numericStepper.MaxValue = short.MaxValue;
            Setup();
        }

        public SpinBox(Ref<int> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = int.MinValue;
            //numericStepper.MaxValue = int.MaxValue;
            Setup();
        }

        public SpinBox(Ref<long> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = long.MinValue;
            //numericStepper.MaxValue = long.MaxValue;
            Setup();
        }

        public SpinBox(Ref<float> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = float.MinValue;
            //numericStepper.MaxValue = float.MaxValue;
            Setup();
        }

        public SpinBox(Ref<double> value, string text = "") : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            //numericStepper.MinValue = double.MinValue;
            //numericStepper.MaxValue = double.MaxValue;
            Setup();
        }

        public SpinBox(string text = "") : base(text)
        {
            Items.Add(numericStepper);
            numericStepper.ValueChanged += OnValueChanged;
            numericStepper.Width = 100;
        }

        private void Setup()
        {
            Items.Add(numericStepper);
            numericStepper.ValueChanged += OnValueChanged;
            numericStepper.Width = 100;
            SetValue();
        }

        private void SetValue()
        {
            switch (Type.GetTypeCode(_valueType))
            {
                case TypeCode.Byte: numericStepper.Value = Convert.ToDouble(((Ref<byte>)_value).Value); break;
                case TypeCode.UInt16: numericStepper.Value = Convert.ToDouble(((Ref<ushort>)_value).Value); break;
                case TypeCode.UInt32: numericStepper.Value = Convert.ToDouble(((Ref<uint>)_value).Value); break;
                case TypeCode.UInt64: numericStepper.Value = Convert.ToDouble(((Ref<ulong>)_value).Value); break;
                case TypeCode.SByte: numericStepper.Value = Convert.ToDouble(((Ref<sbyte>)_value).Value); break;
                case TypeCode.Int16: numericStepper.Value = Convert.ToDouble(((Ref<short>)_value).Value); break;
                case TypeCode.Int32: numericStepper.Value = Convert.ToDouble(((Ref<int>)_value).Value); break;
                case TypeCode.Int64: numericStepper.Value = Convert.ToDouble(((Ref<long>)_value).Value); break;
                case TypeCode.Single: numericStepper.Value = Convert.ToDouble(((Ref<float>)_value).Value); break;
                case TypeCode.Double: numericStepper.Value = Convert.ToDouble(((Ref<double>)_value).Value); break;
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            switch (Type.GetTypeCode(_valueType))
            {
                case TypeCode.Byte: ((Ref<byte>)_value).Value = (byte)numericStepper.Value; break;
                case TypeCode.UInt16: ((Ref<ushort>)_value).Value = (ushort)numericStepper.Value; break;
                case TypeCode.UInt32: ((Ref<uint>)_value).Value = (uint)numericStepper.Value; break;
                case TypeCode.UInt64: ((Ref<ulong>)_value).Value = (ulong)numericStepper.Value; break;
                case TypeCode.SByte: ((Ref<sbyte>)_value).Value = (sbyte)numericStepper.Value; break;
                case TypeCode.Int16: ((Ref<short>)_value).Value = (short)numericStepper.Value; break;
                case TypeCode.Int32: ((Ref<int>)_value).Value = (int)numericStepper.Value; break;
                case TypeCode.Int64: ((Ref<long>)_value).Value = (long)numericStepper.Value; break;
                case TypeCode.Single: ((Ref<float>)_value).Value = (float)numericStepper.Value; break;
                case TypeCode.Double: ((Ref<double>)_value).Value = (double)numericStepper.Value; break;
            }
        }

        public void ChangeReferenceValue(Ref<byte> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<ushort> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<uint> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<ulong> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<sbyte> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<short> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<int> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<long> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<float> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }

        public void ChangeReferenceValue(Ref<double> value)
        {
            _valueType = value.Value.GetType();
            _value = value;
            SetValue();
        }
    }
}