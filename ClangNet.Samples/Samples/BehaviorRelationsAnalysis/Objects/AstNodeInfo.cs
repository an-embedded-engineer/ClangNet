using System.IO;

namespace ClangNet.Samples
{
    /// <summary>
    /// AST Node Info
    /// </summary>
    public abstract class AstNodeInfo
    {
        /// <summary>
        /// Location
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        public AstNodeInfo(ClangCursor cursor)
        {
            this.Location = this.GetLocation(cursor);
        }

        /// <summary>
        /// Get Location
        /// </summary>
        /// <param name="cursor">Clang Cursor</param>
        /// <returns>Location String</returns>
        public string GetLocation(ClangCursor cursor)
        {
            var loc = cursor.Location;

            if (loc != null)
            {
                var floc = loc.FileLocation;

                if (floc != null)
                {
                    if(floc.File != null)
                    {
                        var path = Path.GetFullPath(floc.File.FileName);

                        var line = floc.Line;

                        var col = floc.Column;

                        var location = $"{path}[L.{line},C.{col}]";

                        return location;
                    }
                    else
                    {
                        var line = floc.Line;

                        var col = floc.Column;

                        var location = $"[L.{line},C.{col}]";

                        return location;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
