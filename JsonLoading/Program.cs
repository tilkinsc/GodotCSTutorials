using Godot;
using System.Collections.Generic;
using System.Text.Json;

public class JsonData
{
	public int money;
	public int hp;
	public string name;
}

public static class Program
{
	
	public static void LoadJsonExample()
	{
		string file = @"res://Data/test.json";
		
		// Godot.FileAccess
		FileAccess fileAccess = FileAccess.Open(file);
		if (file == null)
		{
			Error error = FileAccess.GetOpenError();
			if (error != Error.Ok)
			{
				throw new IOException($"Failed to load json file {file}");
			}
			throw new Exception("Unknown exception occurred in LoadJsonExample");
		}
		
		string jsonString = fileAccess.GetAsText();
		List<JsonData> data;
		try
		{
			data = JsonSerializer.Deserialize<List<JsonData>>(jsonString);
		}
		catch (Exception e)
		{
			GD.PrintErr(e.ToString());
			throw;
		}
		
		// use data here, return it, whatever you want
	}
	
}
