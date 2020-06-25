using System;
using System.Runtime.CompilerServices;

namespace SoftStar
{
	public class DynamicFloat
	{
		protected float mMinValue;

		protected float mMaxValue;

		protected float mAdd;

		protected float mScale = 1f;

		protected float result;

		protected bool mIsOverdraw;

		public event Action<float> OnChangeValue;

        public float MinValue
		{
			get
			{
				return this.mMinValue;
			}
			set
			{
				this.mMinValue = value;
				this.Calculate();
			}
		}

		public float MaxValue
		{
			get
			{
				return this.mMaxValue;
			}
			set
			{
				this.mMaxValue = value;
				this.Calculate();
			}
		}

		public float Add
		{
			get
			{
				return this.mAdd;
			}
		}

		public float Scale
		{
			get
			{
				return this.mScale;
			}
		}

		public bool IsOverdraw
		{
			get
			{
				return this.mIsOverdraw;
			}
		}

		public DynamicFloat() : this(-3.40282347E+38f, 3.40282347E+38f)
		{
		}

		public DynamicFloat(float inMinValue, float inMaxValue)
		{
			this.mMinValue = inMinValue;
			this.mMaxValue = inMaxValue;
		}

		public void ChangeAdd(float newValue)
		{
			this.mAdd += newValue;
			this.Calculate();
		}

		public void SetAdd(float newValue)
		{
			this.mAdd = newValue;
			this.Calculate();
		}

		public void ChangeScale(float newValue)
		{
			this.mScale += newValue;
			this.Calculate();
		}

		public void SetScale(float newValue)
		{
			this.mScale = newValue;
			this.Calculate();
		}

		public virtual void Calculate()
		{
			float num = this.result;
			this.result = this.mAdd * this.mScale;
			if (this.result < this.mMinValue)
			{
				this.mIsOverdraw = true;
				this.result = this.mMinValue;
			}
			else if (this.result > this.mMaxValue)
			{
				this.result = this.mMaxValue;
			}
			if (num != this.result && this.OnChangeValue != null)
			{
				this.OnChangeValue(num);
			}
		}

		protected void ChangeValue(float oldValue)
		{
			if (this.OnChangeValue != null)
			{
				this.OnChangeValue(oldValue);
			}
		}

		public override string ToString()
		{
			return this.ToString();
		}

		public static implicit operator float(DynamicFloat d)
		{
			return d.result;
		}
	}
}
