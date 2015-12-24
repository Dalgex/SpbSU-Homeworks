using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    /// <summary>
    /// Предоставляет пользовательский интерфейс
    /// </summary>
    public partial class Editor : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private History history = new History();
        private ActionsOnShapes actions = new ActionsOnShapes();
        private PaintingInAction paintingInAction;
        private KeyboardShortcut keyboardShortcut;

        private Color color = Color.Black; // задаем изначальный цвет линий
        private int width = 2; // задаем изначальную толщину линий

        public Editor()
        {
            InitializeComponent();
            paintingInAction = new PaintingInAction(buttonForMoving, buttonForRemoving, history, shapes);
            keyboardShortcut = new KeyboardShortcut(buttonForUndo, buttonForRedo);
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(shapes);
            paintingInAction.DefineActionAndCallAppropriateMethods(e, pictureBox, color, width);
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(shapes);
            paintingInAction.CallLineBuilding(e, pictureBox);
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            paintingInAction.Update(shapes);
            paintingInAction.AddLineInHistory();
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            paintingInAction.Update(shapes);
            paintingInAction.RepaintAll(e);
            buttonForMoving.Enabled = true;
            buttonForRemoving.Enabled = true;
        }

        private void OnColorClick(object sender, EventArgs e)
        {
            var colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
        }

        private void OnWidthItemClick(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            width = Convert.ToInt32(toolStripMenuItem.Text);
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            if (shapes.Count != 0)
            {
                actions.RemoveAllShapes(ref shapes, history);
                pictureBox.Invalidate();
            }
        }

        private void OnCommandClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
        }

        private void OnUndoClick(object sender, EventArgs e)
        {
            history.Undo(shapes);
            pictureBox.Invalidate();
        }

        private void OnRedoClick(object sender, EventArgs e)
        {
            history.Redo(shapes);
            pictureBox.Invalidate();
        }

        private void EditorKeyDown(object sender, KeyEventArgs e)
        {
            keyboardShortcut.SimulateKeypress(e);
        }

        private void OnWidthClick(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
