using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace CMS.Core.Extensions
{
	public static class ConversionExtensions
    {

        #region Stream

        public static byte[] ToByteArray(this Stream stream)
        {
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			if (stream is MemoryStream mem)
			{
				if (mem.TryGetBuffer(out var buffer))
				{
					return buffer.Array;
				}

				return mem.ToArray();
			}
			else
			{
				using (var streamReader = new MemoryStream())
				{
					stream.CopyTo(streamReader);
					return streamReader.ToArray();
				}
			}
		}

		public static async Task<byte[]> ToByteArrayAsync(this Stream stream)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			if (stream is MemoryStream mem)
			{
				if (mem.TryGetBuffer(out var buffer))
				{
					return buffer.Array;
				}

				return mem.ToArray();
			}
			else
			{
				using (var streamReader = new MemoryStream())
				{
					await stream.CopyToAsync(streamReader);
					return streamReader.ToArray();
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string AsString(this Stream stream)
		{
			return stream.AsString(Encoding.UTF8);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<string> AsStringAsync(this Stream stream)
		{
			return stream.AsStringAsync(Encoding.UTF8);
		}

		public static string AsString(this Stream stream, Encoding encoding)
        {
			if (encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			// convert stream to string
			string result;

			if (stream.CanSeek)
			{
				stream.Position = 0;
			}

            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

		public static Task<string> AsStringAsync(this Stream stream, Encoding encoding)
		{
			if (encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			// convert stream to string
			Task<string> result;

			if (stream.CanSeek)
			{
				stream.Position = 0;
			}

			using (StreamReader sr = new StreamReader(stream, encoding))
			{
				result = sr.ReadToEndAsync();
			}

			return result;
		}

		#endregion

		#region ByteArray

		/// <summary>
		/// Converts a byte array into an object.
		/// </summary>
		/// <param name="bytes">Object to deserialize. May be null.</param>
		/// <returns>Deserialized object, or null if input was null.</returns>
		public static object ToObject(this byte[] bytes)
        {
            if (bytes == null)
                return null;

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return new BinaryFormatter().Deserialize(stream);
            }
        }

        public static Stream ToStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

		/// <summary>
		/// Compresses the input buffer with <see cref="GZipStream"/>
		/// </summary>
		/// <param name="buffer">Decompressed input</param>
		/// <returns>The compressed result</returns>
		public static byte[] Zip(this byte[] buffer)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			using (var compressedStream = new MemoryStream())
			using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
			{
				zipStream.Write(buffer, 0, buffer.Length);
				zipStream.Close();
				return compressedStream.ToArray();
			}
		}

		/// <summary>
		/// Decompresses the input buffer with <see cref="GZipStream"/> decompression
		/// </summary>
		/// <param name="buffer">Compressed input</param>
		/// <returns>The decompressed result</returns>
		public static byte[] UnZip(this byte[] buffer)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			using (var compressedStream = new MemoryStream(buffer))
			using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
			using (var resultStream = new MemoryStream())
			{
				zipStream.CopyTo(resultStream);
				return resultStream.ToArray();
			}
		}

        #endregion

    }

}
