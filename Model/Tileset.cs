using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEditorWPF.Model
{
    public class Tileset
    {
        public required string Name { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TileCount { get; set; }
        public int Columns { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int Margin { get; set; }
        public int Spacing { get; set; }
        public required string Image { get; set; }
        public List<Tile>? Tiles { get; set; }
    }

    public class Tile
    {
        public int Id { get; set; }
        public Dictionary<string, string>? Properties { get; set; }
    }
}
