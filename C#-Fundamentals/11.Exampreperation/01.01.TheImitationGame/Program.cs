string message = Console.ReadLine();

while(true)
{
    string[] input = Console.ReadLine().Split("|");
    if (input[0]=="Decode")
    {
        break;
    }
    if (input[0] == "Move")
    {
        int nums = int.Parse(input[1]);
        string substring = message.Substring(0, nums);
        message = message.Remove(0, nums);
        message = message + substring;

    }
    if (input[0] == "Insert")
    {
        if (int.Parse(input[1]) > message.Length) 
        {
            continue;
        }
       message =  message.Insert(int.Parse(input[1]), input[2]);
    }
    if (input[0] == "ChangeAll")
    {
       message = message.Replace(input[1], input[2]);    
    }
}
Console.WriteLine($"The decrypted message is: {message}");