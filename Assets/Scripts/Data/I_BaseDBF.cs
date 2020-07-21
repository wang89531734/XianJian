using System;

public interface I_BaseDBF
{
	int GetGUID();

	void ParseJson(string JsonString, IConverter Converter, I_BaseDBF Record);
}
