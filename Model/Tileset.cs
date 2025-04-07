using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TileEditorWPF.Model
{
    public class Tileset
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("tilewidth")]
        public int TileWidth { get; set; }
        [JsonPropertyName("tileheight")]
        public int TileHeight { get; set; }
        [JsonPropertyName("tilecound")]
        public int TileCount { get; set; }
        [JsonPropertyName("columns")]
        public int Columns { get; set; }
        [JsonPropertyName("imagewidth")]
        public int ImageWidth { get; set; }
        [JsonPropertyName("imageheight")]
        public int ImageHeight { get; set; }
        [JsonPropertyName("margin")]
        public int Margin { get; set; }
        [JsonPropertyName("spacing")]
        public int Spacing { get; set; }
        [JsonPropertyName("image")]
        public required string Image { get; set; }
        [JsonPropertyName("tiles")]
        public List<Tile>? Tiles { get; set; }
    }

    public class Tile
    {
        [JsonPropertyName("name")]
        public int Id { get; set; }
        [JsonPropertyName("properties")]
        public Dictionary<string, string>? Properties { get; set; }
    }
}
