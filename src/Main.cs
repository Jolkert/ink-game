namespace Ink;

internal static class Program
{
	// this can be set to null because it's initialized first thing in Main() -morgan 2024-05-22
	public static InkGame GameInstance { get; private set; } = null!;

	private static void Main()
	{
		GameInstance = new InkGame();
		GameInstance.Run();
	}
}