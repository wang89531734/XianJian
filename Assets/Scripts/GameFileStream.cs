using ICSharpCode.SharpZipLib.GZip;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameFileStream : IDisposable
{
	private FileStream m_Stream;

	private MemoryStream m_MemoryStream;

	private BinaryWriter m_BinWriter;

	private BinaryReader m_BinReader;

	private int m_Size;

	private FileMode m_FileMode;

	private GameFileFormat m_GameFileFormat;

	private long m_HeaderLength;

	private bool disposed;

	private GameFileStream(string fileName, FileMode fileMode, GameFileFormat gameFileFormat)
	{
		if (fileMode == FileMode.Create)
		{
			this.m_Stream = File.Create(fileName);
			this.m_MemoryStream = new MemoryStream(524288);
			this.m_BinWriter = new BinaryWriter(this.m_MemoryStream);
		}
		else
		{
			if (fileMode != FileMode.Open)
			{
				throw new NotSupportedException();
			}
			byte[] buffer = File.ReadAllBytes(fileName);
			this.m_MemoryStream = new MemoryStream(buffer);
			this.m_BinReader = new BinaryReader(this.m_MemoryStream);
		}
		this.m_FileMode = fileMode;
		this.m_GameFileFormat = gameFileFormat;
		this.m_HeaderLength = 0L;
		this.m_Size = 0;
		this.disposed = false;
	}

	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing)
			{
				if (this.m_FileMode == FileMode.Create)
				{
					this.Flush();
					if (this.m_Stream != null)
					{
						this.m_Stream.Dispose();
					}
					if (this.m_BinWriter != null)
					{
						this.m_BinWriter.Close();
					}
				}
				else if (this.m_FileMode == FileMode.Open && this.m_BinReader != null)
				{
					this.m_BinReader.Close();
				}
				if (this.m_MemoryStream != null)
				{
					this.m_MemoryStream.Dispose();
				}
			}
			this.m_Stream = null;
			this.m_MemoryStream = null;
			this.m_BinWriter = null;
			this.m_BinReader = null;
			this.disposed = true;
		}
	}

	public static GameFileStream Create(string filename, GameFileFormat gameFileFormat)
	{
		return new GameFileStream(filename, FileMode.Create, gameFileFormat);
	}

	public static GameFileStream Open(string filename, GameFileFormat gameFileFormat)
	{
		return new GameFileStream(filename, FileMode.Open, gameFileFormat);
	}

	public void Close()
	{
		if (this.m_Stream != null)
		{
			this.m_Stream.Close();
		}
	}

	public int GetSize()
	{
		return this.m_Size;
	}

	public long GetLength()
	{
		return this.m_MemoryStream.Length;
	}

	public bool IsEnd()
	{
		return (long)this.GetSize() >= this.GetLength();
	}

	public void WriteHeader(object data)
	{
		this.WriteObjData(data);
		this.m_HeaderLength = this.m_MemoryStream.Length;
	}

	public void WriteSystemHeader(object data)
	{
		this.WriteObjData(data);
		this.m_HeaderLength = this.m_MemoryStream.Length;
	}

	public void WriteObjData(object data)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(this.m_MemoryStream, data);
		this.m_Size = (int)this.m_MemoryStream.Position;
	}

	public void WriteByteArray(byte[] data, int size)
	{
		this.m_Size += size;
		this.m_MemoryStream.Write(data, 0, size);
	}

	public void WriteInt(int data)
	{
		this.m_BinWriter.Seek(this.m_Size, SeekOrigin.Begin);
		this.m_Size += 4;
		this.m_BinWriter.Write(data);
	}

	public void WriteBool(bool data)
	{
		this.m_BinWriter.Seek(this.m_Size, SeekOrigin.Begin);
		this.m_Size++;
		this.m_BinWriter.Write(data);
	}

	public void WriteFloat(float data)
	{
		this.m_BinWriter.Seek(this.m_Size, SeekOrigin.Begin);
		this.m_Size += 4;
		this.m_BinWriter.Write(data);
	}

	public void WriteString(string data)
	{
		this.m_BinWriter.Seek(this.m_Size, SeekOrigin.Begin);
		this.m_Size += 4;
		this.m_BinWriter.Write(data.Length);
		this.m_Size += data.Length;
		this.m_BinWriter.Write(data);
	}

	public void WriteVector3(Vector3 data)
	{
		this.m_BinWriter.Seek(this.m_Size, SeekOrigin.Begin);
		this.m_Size += 4;
		this.m_BinWriter.Write(data.x);
		this.m_Size += 4;
		this.m_BinWriter.Write(data.y);
		this.m_Size += 4;
		this.m_BinWriter.Write(data.z);
	}

	public void Flush()
	{
		if (this.m_FileMode == FileMode.Create)
		{
			if (this.m_GameFileFormat == GameFileFormat.Normal)
			{
				this.m_Stream.Write(this.m_MemoryStream.ToArray(), 0, this.m_Size);
			}
			else
			{
				byte[] array = this.m_MemoryStream.ToArray();
				if (this.m_HeaderLength != 0L)
				{
					this.m_Stream.Write(array, 0, (int)this.m_HeaderLength);
				}
				int count = (int)(this.m_MemoryStream.Length - this.m_HeaderLength);
				MemoryStream memoryStream = new MemoryStream();
				GZipOutputStream gZipOutputStream = new GZipOutputStream(memoryStream);
				gZipOutputStream.Write(array, (int)this.m_HeaderLength, count);
				gZipOutputStream.Close();
				byte[] array2 = memoryStream.ToArray();
				int count2 = array2.Length;
				this.m_Stream.Write(array2, 0, count2);
				this.m_Stream.Close();
			}
		}
	}

	public void ReadHeader(out SaveHeader saveHeader)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		saveHeader = (SaveHeader)binaryFormatter.Deserialize(this.m_MemoryStream);
		this.m_Size += (int)this.m_MemoryStream.Position;
	}

	public void ReadObjData(out object data)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		data = binaryFormatter.Deserialize(this.m_MemoryStream);
		this.m_Size = (int)this.m_MemoryStream.Position;
	}

	public void ReadHeaderData(out object data)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		data = binaryFormatter.Deserialize(this.m_MemoryStream);
		this.m_Size = (int)this.m_MemoryStream.Position;
		this.m_HeaderLength = (long)this.m_Size;
	}

	public void ReadByteArray(byte[] data, int size)
	{
		this.m_Size += size;
		this.m_MemoryStream.Read(data, 0, size);
	}

	public int ReadInt()
	{
		byte[] array = new byte[4];
		this.m_MemoryStream.Read(array, 0, 4);
		this.m_Size += 4;
		return BitConverter.ToInt32(array, 0);
	}

	public bool ReadBool()
	{
		int num = 1;
		byte[] array = new byte[num];
		this.m_MemoryStream.Read(array, 0, num);
		this.m_Size += num;
		return BitConverter.ToBoolean(array, 0);
	}

	public float ReadFloat()
	{
		byte[] array = new byte[4];
		this.m_MemoryStream.Read(array, 0, 4);
		this.m_Size += 4;
		return BitConverter.ToSingle(array, 0);
	}

	public string ReadString()
	{
		int num = this.ReadInt();
		byte[] array = new byte[num];
		this.m_MemoryStream.Read(array, 0, num);
		this.m_Size += num;
		return BitConverter.ToString(array);
	}

	public Vector3 ReadVector3()
	{
		int num = 12;
		byte[] array = new byte[num];
		this.m_MemoryStream.Read(array, 0, num);
		this.m_Size += 4;
		Vector3 result;
		result.x = BitConverter.ToSingle(array, 0);
		this.m_Size += 4;
		result.y = BitConverter.ToSingle(array, 4);
		this.m_Size += 4;
		result.z = BitConverter.ToSingle(array, 8);
		return result;
	}

	public void StreamToFile(Stream stream, string fileName)
	{
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		stream.Seek(0L, SeekOrigin.Begin);
		FileStream fileStream = new FileStream(fileName, FileMode.Create);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		binaryWriter.Write(array);
		binaryWriter.Close();
		fileStream.Close();
	}

	public Stream FileToStream(string fileName)
	{
		FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		this.m_MemoryStream = new MemoryStream(array);
		return this.m_MemoryStream;
	}

	public void Decompress()
	{
		byte[] array = new byte[4096];
		GZipInputStream gZipInputStream = new GZipInputStream(this.m_MemoryStream);
		MemoryStream memoryStream = new MemoryStream();
		int num = 0;
		int num2;
		while ((num2 = gZipInputStream.Read(array, 0, array.Length)) != 0)
		{
			memoryStream.Write(array, 0, num2);
			num += num2;
		}
		this.m_MemoryStream.Close();
		this.m_MemoryStream = memoryStream;
		this.m_MemoryStream.Seek(0L, SeekOrigin.Begin);
	}
}
