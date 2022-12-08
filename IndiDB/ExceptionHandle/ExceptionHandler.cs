using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB.ExceptionHandle
{
    internal static class ExceptionHandler
    {
        public static void CheckValidFormat(Action action)
        {
			try
			{
				action();
			}
			catch (FormatException ex)
			{
                MessageBox.Show(ex.Message, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
