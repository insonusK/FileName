﻿using System;

namespace File.Name
{
    public struct FileName:IEquatable<FileName>
    {
        public FileName(string fileName) : this()
        {
            if (fileName == "") throw new Exception("File Name could not be empty");

            var fileNameArr = fileName.Split(".");

            this.Name = fileNameArr[0];
            for (int i = 1; i < fileNameArr.Length - 1; i++)
            {
                this.Name = string.Concat(this.Name, ".", fileNameArr[i]);
            }

            if (fileNameArr.Length > 1)
            {
                this.Extension = fileNameArr[fileNameArr.Length - 1];
            }
        }
        public FileName(string name, string extension) : this()
        {
            this.Name = name;
            this.Extension = extension;
        }

        public readonly string Name;
        public readonly string Extension;

        #region Equality members

        /// <inheritdoc />
        public bool Equals(FileName other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Extension, other.Extension);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is FileName other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Extension != null ? Extension.GetHashCode() : 0);
            }
        }

        /// <inheritdoc />
        public override string ToString() => Extension == null ? Name : $"{Name}.{Extension}";

        #endregion
    }
}
