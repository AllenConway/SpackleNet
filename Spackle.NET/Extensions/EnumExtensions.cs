﻿using System;
using System.ComponentModel;

namespace Spackle.Extensions
{
	/// <summary>
	/// Provides extension methods for enumerations.
	/// </summary>
	public static class EnumExtensions
	{
		private const string ErrorValueNotEnum = "The type of the given value is not an enumeration.";

		/// <summary>
		/// Gets the description for a enumeration value if the value has been attributed with <see cref="DescriptionAttribute"/>.
		/// </summary>
		/// <typeparam name="T">The type of the enumeration.</typeparam>
		/// <param name="this">The value of the enumeration.</param>
		/// <returns>A description for the enumeration value, or <code>string.Empty</code> if none exists.</returns>
		/// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enumeration.</exception>
		public static string GetDescription<T>(this T @this)
		{
			var thisType = typeof(T);

			if(!thisType.IsEnum)
			{
				throw new ArgumentException(EnumExtensions.ErrorValueNotEnum, "this");
			}

			var description = string.Empty;
			var thisField = thisType.GetField(Enum.GetName(thisType, @this));

			if(thisField != null)
			{
				var descriptions = thisField.GetCustomAttributes(typeof(DescriptionAttribute), true);

				if(descriptions != null && descriptions.Length > 0)
				{
					description = ((DescriptionAttribute)descriptions[0]).Description;
				}
			}

			return description;
		}

		/// <summary>
		/// Gets the name for a enumeration value.
		/// </summary>
		/// <typeparam name="T">The type of the enumeration.</typeparam>
		/// <param name="this">The value of the enumeration.</param>
		/// <returns>The name for the enumeration value.</returns>
		/// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enumeration.</exception>
		public static string GetName<T>(this T @this)
		{
			var thisType = typeof(T);

			if(!thisType.IsEnum)
			{
				throw new ArgumentException(EnumExtensions.ErrorValueNotEnum, "this");
			}

			return Enum.GetName(thisType, @this);
		}
	}
}
