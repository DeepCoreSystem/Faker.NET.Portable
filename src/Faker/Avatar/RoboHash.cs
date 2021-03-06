﻿using System;
using System.Text.RegularExpressions;
using Faker.Extensions;

namespace Faker
{
	/// <summary>
	///   What kind of image will be generated.
	/// </summary>
	/// <remarks>When version 3.0 hits, this will be in Faker.Avatar namespace.</remarks>
	public enum RoboHashImageFormat
	{
		/// <summary>
		///   A PNG image
		/// </summary>
		png,

		/// <summary>
		///   A JPG image
		/// </summary>
		jpg,

		/// <summary>
		///   A BMP image
		/// </summary>
		bmp
	}

	/// <summary>
	///   A collection of RoboHash.org avatar related resources.
	/// </summary>
	/// <threadsafety static="true" />
	/// <remarks>When version 3.0 hits, this will be in Faker.Avatar namespace.</remarks>
	/// <seealso cref="FlatHash" />
	public static class RoboHash
	{
		/// <summary>
		///   Gets a random RoboHash.org image URL.
		/// </summary>
		/// <param name="slug">The optional slug to set instead of generating a new random slug.</param>
		/// <param name="size">The image size</param>
		/// <param name="format">The image format</param>
		/// <param name="set">The image set to use in url generation</param>
		/// <returns>The randomly generated Robo hash image URL.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="set" /> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentException">Size should be specified in format 300x300</exception>
		/// <seealso cref="FlatHash.Image(string, FlatHashImageFormat)" />
		public static string Image(
			string slug = null,
			string size = "300x300",
			RoboHashImageFormat format = RoboHashImageFormat.png,
			string set = "set1")
		{
			if (set == null)
			{
				throw new ArgumentNullException("set");
			}

			if (!Regex.IsMatch(size, @"^[0-9]+x[0-9]+$"))
			{
				throw new ArgumentException("Size should be specified in format 300x300", "size");
			}

			slug = slug ?? string.Join(string.Empty, Lorem.Words(3));

			return "http://robohash.org/{0}.{2}?size={1}&set={3}"
				.FormatCulture(
					slug,
					size,
					format,
					set);
		}
	}
}
