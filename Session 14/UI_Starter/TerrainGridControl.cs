using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Starter
{

    public class TerrainGridControl : Control
    {
        private int[,] terrainMap;
        private readonly Dictionary<int, Color> terrainColors;


        public TerrainGridControl()
        {
            terrainColors = new Dictionary<int, Color>
            {
                { 0, Color.Blue },    // Water
                { 1, Color.Green },   // Grass
                { 2, Color.Brown },   // Mountain
                { 3, Color.Gray }     // Rock
                };


            terrainMap = new int[,]
            {
                 { 0, 1, 2, 3 },
                 { 1, 2, 3, 0 },
                 { 2, 3, 0, 1 },
                 { 3, 0, 1, 2 }
            };
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (terrainMap == null)
                return;
            int rows = terrainMap.GetLength(0);
            int cols = terrainMap.GetLength(1);
            if (rows == 0 || cols == 0)
                return;
            // Work with client size (exclude borders)
            int width = ClientSize.Width;
            int height = ClientSize.Height;
            if (width <= 0 || height <= 0)
                return;
            // Size of each cell so the whole grid fits.
            int cellWidth = width / cols;
            int cellHeight = height / rows;
            int cellSize = Math.Min(cellWidth, cellHeight);
            if (cellSize <= 0)
                return;
            using (var pen = new Pen(Color.Black))
            {
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        int terrainValue = terrainMap[y, x];
                        Color color;
                        if (!terrainColors.TryGetValue(terrainValue, out color))
                            color = Color.Magenta; // unknown terrain type
                        int px = x * cellSize;
                        int py = y * cellSize;
                        var rect = new Rectangle(px, py, cellSize, cellSize);
                        using (var brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                }
            }
        }
    }
}