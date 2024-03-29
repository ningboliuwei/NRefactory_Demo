﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
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
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;

namespace StringIndexOf
{
	public class CSharpFile
	{
		public readonly CSharpProject Project;
		public readonly string FileName;
		public readonly string OriginalText;
		
		public SyntaxTree SyntaxTree;
		public CSharpUnresolvedFile UnresolvedTypeSystemForFile;
		
		public CSharpFile(CSharpProject project, string fileName)
		{
			this.Project = project;
			this.FileName = fileName;
			
			CSharpParser p = new CSharpParser(project.CompilerSettings);
//			using (var stream = File.OpenRead(fileName)) {
//				this.CompilationUnit = p.Parse(stream, fileName);
//			}
			
			// Keep the original text around; we might use it for a refactoring later
			this.OriginalText = File.ReadAllText(fileName);
			this.SyntaxTree = p.Parse(this.OriginalText, fileName);
			
			if (p.HasErrors) {
				Console.WriteLine("Error parsing " + fileName + ":");
				foreach (var error in p.ErrorsAndWarnings) {
					Console.WriteLine("  " + error.Region + " " + error.Message);
				}
			}
			this.UnresolvedTypeSystemForFile = this.SyntaxTree.ToTypeSystem();
		}
		
		public CSharpAstResolver CreateResolver()
		{
			return new CSharpAstResolver(Project.Compilation, SyntaxTree, UnresolvedTypeSystemForFile);
		}
		
		public List<InvocationExpression> IndexOfInvocations = new List<InvocationExpression>();
	}
}
