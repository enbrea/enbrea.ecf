#region ENBREA ECF - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA ECF
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Enbrea.Ecf
{
    /// <summary>
    /// Represents a date of day.
    /// </summary>
    /// <remarks>
    /// This type was introduced to differentiate between the classical <see cref="DateTime"/> type which 
    /// includes time information and a date only type (e.g. for birthdays).
    /// </remarks>
    [Serializable]
	public readonly struct Date : IComparable, IComparable<Date>, IEquatable<Date>, IFormattable, ISerializable
    {
        public static readonly Date MaxValue = new Date(DateTime.MaxValue);
        public static readonly Date MinValue = new Date(DateTime.MinValue);
        public static readonly Date UnixEpoch = new Date(DateTime.UnixEpoch);
        
        private const string TicksField = "ticks"; // Do not rename (binary serialization)        
       
        private readonly DateTime _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="year">The year (1 through 9999).</param>
        /// <param name="month">The month (1 through 12).</param>
        /// <param name="day">The day (1 through the number of days in month).</param>
        public Date(int year, int month, int day)
        {
            _value = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="dateTime">A DateTime value. Only the date part is taken.</param>
        public Date(DateTime dateTime)
        {
            _value = dateTime.Date;
        }

        /// <summary>
        /// Private constructor for the serializer.
        /// </summary>
        private Date(SerializationInfo info, StreamingContext context)
        {
            _value = new DateTime(info.GetInt64(TicksField));
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        public static Date Today
        {
            get
            {
                return new Date(DateTime.Today);
            }
        }

        /// <summary>
        /// Explicit type conversion to <see cref="DateTime"/>
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        public int Day
        {
            get
            {
                return _value.Day;
            }
        }

        /// <summary>
        /// Gets the day of the week represented by this instance.
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get
            {
                return _value.DayOfWeek;
            }
        }

        /// <summary>
        /// Gets the day of the year represented by this instance.
        /// </summary>
        public int DayOfYear
        {
            get
            {
                return _value.DayOfYear;
            }
        }

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        public int Month
        {
            get
            {
                return _value.Month;
            }
        }

        /// <summary>
        /// Gets the number of ticks that represent the date of this instance.
        /// </summary>
        public long Ticks
        {
            get
            {
                return _value.Ticks;
            }
        }

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        public int Year
        {
            get
            {
                return _value.Year;
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="Date"/> and returns an integer that indicates whether the 
        /// first instance is earlier than, the same as, or later than the second instance.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>
        /// A signed number indicating the relative values of left and right. If less than zero left is earlier 
        /// than right. If zero left is the same as right. If greater than zero left is later than right.
        /// </returns>
        public static int Compare(Date left, Date right)
        {
            return left.CompareTo(right);
        }

        /// <summary>
        /// Returns the number of days in the specified month and year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month (a number ranging from 1 to 12).</param>
        /// <returns>
        /// The number of days in month for the specified year. For example, if month equals 2 for February, 
        /// the return value is 28 or 29 depending upon whether year is a leap year.
        /// </returns>
        public static int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        /// <summary>
        /// Returns a value indicating whether two instances of <see cref="Date"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if both instances are equal; otherwise, false.</returns>
        public static bool Equals(Date left, Date right)
        {
            return left._value.Equals(right._value);
        }

        /// <summary>
        /// Explicit type conversion from <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">A <see cref="DateTime"/> instance</param>
        public static explicit operator Date(DateTime dateTime)
        {
            return new Date(dateTime);
        }

        /// <summary>
        /// Returns an indication whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">A 4-digit year.</param>
        /// <returns>True if year is a leap year; otherwise, false.</returns>
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        ///  Determines whether two specified instances of <see cref="Date"/> are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if left and right do not represent the same date; otherwise, false.</returns>
        public static bool operator !=(Date left, Date right)
		{
			return left._value != right._value;
		}

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> is earlier than another specified
        /// <see cref="Date"/>.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if left is earlier than right; otherwise, false.</returns>
        public static bool operator <(Date left, Date right)
		{
			return left._value < right._value;
		}

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a date and time that is the 
        /// same as or earlier than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if left is the same as or earlier than right; otherwise, false.</returns>
        public static bool operator <=(Date left, Date right)
		{
			return left._value <= right._value;
		}

        /// <summary>
        /// Determines whether two specified instances of <see cref="Date"/> are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if left and right represent the same date; otherwise, false.</returns>
        public static bool operator ==(Date left, Date right)
		{
			return left._value == right._value;
		}

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> is later than another specified 
        /// <see cref="Date"/>.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>true if left is later than right; otherwise, false.</returns>
        public static bool operator >(Date left, Date right)
		{
			return left._value > right._value;
		}

        /// <summary>
        /// Determines whether one specified <see cref="Date"/> represents a date and time that is the 
        /// same as or later than another specified <see cref="Date"/>.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns>True if left is the same as or later than right; otherwise, false.</returns>
        public static bool operator >=(Date left, Date right)
		{
			return left._value >= right._value;
		}

        /// <summary>
        /// Converts the string representation of a date to its <see cref="Date"/> equivalent by using the conventions 
        /// of the current thread culture.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s.
        /// </returns>
        public static Date Parse(string s)
        {
            return new Date(DateTime.Parse(s));
        }

        /// <summary>
        /// Converts the string representation of a date to its <see cref="Date"/> equivalent by using culture-specific 
        /// format information.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s as specified by provider.
        /// </returns>
        public static Date Parse(string s, IFormatProvider provider)
        {
            return new Date(DateTime.Parse(s, provider));
        }

        /// <summary>
        /// Converts the string representation of a date to its <see cref="Date"/> equivalent by using culture-specific 
        /// format information and a formatting style.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s, as specified by provider and styles.
        /// </returns>
        public static Date Parse(string s, IFormatProvider provider, DateTimeStyles style)
        {
            return new Date(DateTime.Parse(s, provider, style));
        }

        /// <summary>
        ///  Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        ///  specified format and culture-specific format information. The format of the string representation must 
        ///  match the specified format exactly.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s, as specified by format and provider.
        /// </returns>
        public static Date ParseExact(string s, string format, IFormatProvider provider)
        {
            return new Date(DateTime.ParseExact(s, format, provider));
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        /// specified format, culture-specific format information, and style. The format of the string representation 
        /// must match the specified format exactly or an exception is thrown.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s, as specified by format, provider, and style.
        /// </returns>
        public static Date ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style)
        {
            return new Date(DateTime.ParseExact(s, format, provider, style));
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        /// specified array of formats, culture-specific format information, and style. The format of the string 
        /// representation must match at least one of the specified formats exactly or an exception is thrown.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <returns>
        /// An object that is equivalent to the date contained in s, as specified by format, provider, and style.
        /// </returns>
        public static Date ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style)
        {
            return new Date(DateTime.ParseExact(s, formats, provider, style));
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent and returns 
        /// a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="result">When this method returns, contains the <see cref="Date"/> value equivalent to the
        /// date contained in s, if the conversion succeeded, or <see cref="MinValue"/> if the conversion failed. 
        /// The conversion fails if the s parameter is null, is an empty string (""), or does not contain a valid 
        /// string representation of a date. This parameter is passed uninitialized.</param>
        /// <returns>True if the s parameter was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string s, out Date result)
        {
            bool success = DateTime.TryParse(s, out var dateTime);
            result = new Date(dateTime);
            return success;
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        /// specified culture-specific format information and formatting style, and returns a value that indicates 
        /// whether the conversion succeeded.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <param name="result">When this method returns, contains the <see cref="Date"/> value equivalent to the
        /// date contained in s, if the conversion succeeded, or <see cref="MinValue"/> if the conversion failed. 
        /// The conversion fails if the s parameter is null, is an empty string (""), or does not contain a valid 
        /// string representation of a date. This parameter is passed uninitialized.</param>
        /// <returns>True if the s parameter was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            bool success = DateTime.TryParse(s, provider, style, out var dateTime);
            result = new Date(dateTime);
            return success;
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        /// specified format, culture-specific format information, and style. The format of the string representation 
        /// must match the specified format exactly. The method returns a value that indicates whether the conversion 
        /// succeeded.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <param name="result">When this method returns, contains the <see cref="Date"/> equivalent to the date 
        /// contained in s, if the conversion succeeded, or <see cref="MinValue"/> if the conversion failed. The 
        /// conversion fails if either the s or format parameter is null, is an empty string, or does not contain 
        /// a date that correspond to the pattern specified in format. This parameter is passed uninitialized.</param>
        /// <returns>True if s was converted successfully; otherwise, false.</returns>
        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            bool success = DateTime.TryParseExact(s, format, provider, style, out var dateTime);
            result = new Date(dateTime);
            return success;
        }

        /// <summary>
        /// Converts the specified string representation of a date to its <see cref="Date"/> equivalent using the 
        /// specified format, culture-specific format information, and style. The format of the string representation 
        /// must match the specified format exactly. The method returns a value that indicates whether the conversion 
        /// succeeded.
        /// </summary>
        /// <param name="s">A string containing a date to convert.</param>
        /// <param name="format">The required format of s.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="style">A bitwise combination of one or more enumeration values that indicate the permitted 
        /// format of s.</param>
        /// <param name="result">When this method returns, contains the <see cref="Date"/> equivalent to the date 
        /// contained in s, if the conversion succeeded, or <see cref="MinValue"/> if the conversion failed. The 
        /// conversion fails if either the s or format parameter is null, is an empty string, or does not contain 
        /// a date that correspond to the pattern specified in format. This parameter is passed uninitialized.</param>
        /// <returns>True if s was converted successfully; otherwise, false.</returns>
        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            bool success = DateTime.TryParseExact(s, formats, provider, style, out var dateTime);
            result = new Date(dateTime);
            return success;
        }

        /// <summary>
        /// Returns a new Date that adds the specified number of days to the value
        /// of this instance.
        /// </summary>
        /// <param name="value">A number of days. The value parameter can be negative 
        /// or positive.</param>
        /// <returns>
        /// An object whose value is the sum of the date represented by this instance
        /// and the number of days represented by value.
        /// </returns>
        public Date AddDays(int value)
        {
			return new Date(_value.AddDays(value));
		}

        /// <summary>
        /// Returns a new Date that adds the specified number of months to the value 
        /// of this instance.
        /// </summary>
        /// <param name="value">A number of months. The value parameter can be negative
        /// or positive.</param>
        /// <returns>
        /// An object whose value is the sum of the date represented by this instance
        /// and the number of months represented by value.
        /// </returns>
        public Date AddMonths(int value)
		{
			return new Date(_value.AddMonths(value));
		}

        /// <summary>
        /// Returns a new Date that adds the specified number of years to the value 
        /// of this instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative
        /// or positive.</param>
        /// <returns>
        /// An object whose value is the sum of the date represented by this instance
        /// and the number of years represented by value.
        /// </returns>
		public Date AddYears(int value)
		{
			return new Date(_value.AddYears(value));
		}

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="Date"/> value and
        ///  returns an integer that indicates whether this instance is earlier than, the
        ///  same as, or later than the specified <see cref="Date"/> value.
        /// </summary>
        /// <param name="other">The object to compare to the current instance.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and the given
        /// parameter. If less than zero this instance is earlier than other. If zero this 
        /// instance is the same as other. If greater than zero this instance is later than other.
        /// </returns>
        public int CompareTo(Date other)
		{
			return _value.CompareTo(other._value);
		}

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified
        /// <see cref="Date"/> value, and returns an integer that indicates whether this instance is 
        /// earlier than, the same as, or later than the specified <see cref="Date"/> value.
        /// </summary>
        /// <param name="obj">A boxed object to compare, or null.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value. If less than zero 
        /// this instance is earlier than value. If zero this instance is the same as value. If greater than 
        /// zero This instance is later than value, or value is null.
        /// </returns>
        public int CompareTo(object obj)
		{
			return _value.CompareTo(obj);
		}

        /// <summary>
        /// Returns a value indicating whether the value of this instance is equal to the value 
        /// of the specified Date instance.
        /// </summary>
        /// <param name="date">The object to compare to this instance.</param>
        /// <returns>
        /// True if the value parameter equals the value of this instance; otherwise, false.
        /// </returns>
        public bool Equals(Date date)
		{
			return _value.Equals(date._value);
		}

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>
        /// True if value is an instance of <see cref="Date"/> and equals the value of this instance; 
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
		{
			return obj is Date date && _value.Equals(date._value);
		}

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="StreamingContext"/>) for this
        /// serialization.</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(TicksField, _value.Ticks);
        }

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent long
        /// string representation.
        /// </summary>
        /// <returns>A string that contains the long string representation.</returns>
        public string ToLongString()
		{
			return _value.ToLongDateString();
		}

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent short
        /// string representation.
        /// </summary>
        /// <returns>A string that contains the short string representation.</returns>
		public string ToShortString()
		{
			return _value.ToShortDateString();
		}

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent 
        /// string representation.
        /// </summary>
        /// <returns>A string that contains the string representation.</returns>
        public override string ToString()
		{
			return ToShortString();
		}

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent string 
        /// representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of value of the current <see cref="Date"/> object as specified by provider.
        /// </returns>
		public string ToString(IFormatProvider provider)
		{
			return _value.ToString(provider);
		}

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent string 
        /// representation using the specified format and the formatting conventions of the current culture
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>
        /// A string representation of value of the current <see cref="Date"/> object as specified by format.
        /// </returns>
		public string ToString(string format)
		{
			return _value.ToString(format);
		}

        /// <summary>
        /// Converts the value of the current <see cref="Date"/> object to its equivalent string representation 
        /// using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of value of the current <see cref="Date"/> object as specified by format 
        /// and provider.
        /// </returns>
        public string ToString(string format, IFormatProvider provider)
		{
			return _value.ToString(format, provider);
		}
	}
}