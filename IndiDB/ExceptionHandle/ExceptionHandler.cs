using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IndiDB.ExceptionHandle
{
    internal static class ExceptionHandler
    {
        public static void CheckValidFormat(Action action, int recordId = default)
        {
			try
			{
				action();
			}
			catch (Exception ex)
			{
                switch (ex)
                {
                    case FormatException:
                        MessageBox.Show(ex.Message, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case OverflowException:
                        MessageBox.Show($"Max value is {int.MaxValue}\nMin value is 0", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case EndOfStreamException:
                        MessageBox.Show("File is empty.", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case NullReferenceException:
                        MessageBox.Show($"Record with id: {recordId} does not exists.", "main.data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }
    }
}
