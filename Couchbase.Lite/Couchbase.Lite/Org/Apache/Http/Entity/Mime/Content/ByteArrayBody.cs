/**
 * Couchbase Lite for .NET
 *
 * Original iOS version by Jens Alfke
 * Android Port by Marty Schoch, Traun Leyden
 * C# Port by Zack Gramana
 *
 * Copyright (c) 2012, 2013 Couchbase, Inc. All rights reserved.
 * Portions (c) 2013 Xamarin, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System;
using System.IO;
using Org.Apache.Http.Entity.Mime;
using Org.Apache.Http.Entity.Mime.Content;
using Sharpen;

namespace Org.Apache.Http.Entity.Mime.Content
{
	/// <summary>Body part that is built using a byte array containing a file.</summary>
	/// <remarks>Body part that is built using a byte array containing a file.</remarks>
	/// <since>4.1</since>
	public class ByteArrayBody : AbstractContentBody
	{
		/// <summary>The contents of the file contained in this part.</summary>
		/// <remarks>The contents of the file contained in this part.</remarks>
		private readonly byte[] data;

		/// <summary>The name of the file contained in this part.</summary>
		/// <remarks>The name of the file contained in this part.</remarks>
		private readonly string filename;

		/// <summary>Creates a new ByteArrayBody.</summary>
		/// <remarks>Creates a new ByteArrayBody.</remarks>
		/// <param name="data">The contents of the file contained in this part.</param>
		/// <param name="mimeType">The mime type of the file contained in this part.</param>
		/// <param name="filename">The name of the file contained in this part.</param>
		public ByteArrayBody(byte[] data, string mimeType, string filename) : base(mimeType
			)
		{
			if (data == null)
			{
				throw new ArgumentException("byte[] may not be null");
			}
			this.data = data;
			this.filename = filename;
		}

		/// <summary>Creates a new ByteArrayBody.</summary>
		/// <remarks>Creates a new ByteArrayBody.</remarks>
		/// <param name="data">The contents of the file contained in this part.</param>
		/// <param name="filename">The name of the file contained in this part.</param>
		public ByteArrayBody(byte[] data, string filename) : this(data, "application/octet-stream"
			, filename)
		{
		}

		public override string GetFilename()
		{
			return filename;
		}

		/// <exception cref="System.IO.IOException"></exception>
		public override void WriteTo(OutputStream @out)
		{
			@out.Write(data);
		}

		public override string GetCharset()
		{
			return null;
		}

		public override string GetTransferEncoding()
		{
			return MIME.EncBinary;
		}

		public override long GetContentLength()
		{
			return data.Length;
		}
	}
}
