﻿using System.Diagnostics;
using System.IO;
using System.Linq;

namespace grr.Messages
{
	[System.Diagnostics.DebuggerDisplay("{GetRemoteCommand()}")]
	public class ChangeToDirectoryMessage : DirectoryMessage
	{
		public ChangeToDirectoryMessage(string argument)
			: base(argument)
		{
		}

		protected override void ExecuteExistingDirectory(string directory)
		{
			// use '/' for linux systems and bash command line (will work on cmd and powershell as well)
			directory = directory.Replace(@"\", "/");

			var command = $"cd \"{directory}\"";
			var parentProcess = Process.GetCurrentProcess();
			ConsoleExtensions.WriteConsoleInput(parentProcess, command);
		}
	}
}
