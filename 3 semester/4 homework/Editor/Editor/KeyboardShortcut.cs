using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    /// <summary>
    /// Представляет горячие клавиши
    /// </summary>
    public class KeyboardShortcut
    {
        private Button buttonForUndo;
        private Button buttonForRedo;

        public KeyboardShortcut(Button buttonForUndo, Button buttonForRedo)
        {
            this.buttonForUndo = buttonForUndo;
            this.buttonForRedo = buttonForRedo;
        }

        /// <summary>
        /// Имитирует нажатие клавиш
        /// </summary>
        public void SimulateKeypress(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                buttonForUndo.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                buttonForRedo.PerformClick();
            }
        }
    }
}
