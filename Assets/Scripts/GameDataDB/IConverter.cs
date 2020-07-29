using System;

public interface IConverter
{
	string serializeObject(object data);

	T deserializeObject<T>(string value);

	object deserializeObject(string value, Type type);
}
