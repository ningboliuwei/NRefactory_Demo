// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace StringIndexOf
{
	/// <summary>
	/// This class contains various IndexOf calls.
	/// Only the ones in the first should be detected as missing a StringComparison.
	/// </summary>
	public class Test
	{
		public void StringIndexOfStringCalls(List<string> list)
		{
			list[0].IndexOf(".com");
			list[0].IndexOf(".com", 0);
			list[0].IndexOf(".com", 0, 5);
			list[0].IndexOf(list[1], 0, 10);
		}
		
		public void StringIndexOfStringCallsWithComparison(List<string> list)
		{
			list[0].IndexOf(".com", StringComparison.OrdinalIgnoreCase);
			list[0].IndexOf(".com", 0, StringComparison.OrdinalIgnoreCase);
			list[0].IndexOf(".com", 0, 5, StringComparison.OrdinalIgnoreCase);
			list[0].IndexOf(list[1], 0, 10, StringComparison.OrdinalIgnoreCase);
		}
		
		public void StringIndexOfCharCalls(List<string> list)
		{
			list[0].IndexOf('.');
			Environment.CommandLine.IndexOf('/');
		}
		
		public void OtherIndexOfCalls(List<string> list)
		{
			list.IndexOf(".com");
		}
	}
}
