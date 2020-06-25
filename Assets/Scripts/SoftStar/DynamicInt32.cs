using System;
using System.Runtime.CompilerServices;

namespace SoftStar
{
	public class DynamicInt32
	{
		protected int mMinValue;

		protected int mMaxValue;

		protected int mAdd;

		protected float mScale = 1f;

		protected int result;

		protected bool mIsOverdraw;

        public event Action<int> OnChangeValue;

		public int Add
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

		public DynamicInt32() : this(-2147483648, 2147483647)
		{
		}

		public DynamicInt32(int inMinValue, int inMaxValue) : this(0, inMinValue, inMaxValue)
		{
		}

		public DynamicInt32(int inBase, int inMinValue, int inMaxValue)
		{
			this.mAdd = inBase;
			this.mMinValue = inMinValue;
			this.mMaxValue = inMaxValue;
		}

		public void ChangeAdd(int newValue)
		{
			this.mAdd += newValue;
			this.Calculate();
		}

		public void SetAdd(int newValue)
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
			int num = this.result;
			this.result = (int)((float)this.mAdd * this.mScale);
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

		protected void ChangeValue(int oldValue)
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

		public static implicit operator int(DynamicInt32 d)
		{
			return d.result;
		}
	}
}
