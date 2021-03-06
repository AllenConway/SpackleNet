﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spackle;
using System;

namespace Spackle.Tests
{
	[TestClass]
	public sealed class EventArgsTests : CoreTests
	{
		[TestMethod]
		public void Create()
		{
			var value = new RandomObjectGenerator().Generate<string>();
			var args = new EventArgs<string>(value);
			Assert.AreEqual(value, args.Value);
		}
	}
}
