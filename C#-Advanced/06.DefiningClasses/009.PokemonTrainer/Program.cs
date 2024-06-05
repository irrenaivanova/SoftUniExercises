using _009.PokemonTrainer;

List<Trainer> trainers = new();

while(true)
{
    string[] input = Console.ReadLine().Split();
    if (input[0] == "Tournament")
        break;

    Trainer currTrain = trainers.FirstOrDefault(x => x.Name == input[0]);
    if (currTrain == null)
    {
        currTrain = new(input[0]);
    }
    if (!trainers.Any(x=>x.Name==currTrain.Name))
    {
        trainers.Add(currTrain);
    }
    Pokemon pokemon = new(input[1], input[2], double.Parse(input[3]));
    currTrain.Pokemons.Add(pokemon);
}

while(true)
{
    string element = Console.ReadLine();
    if (element == "End")
        break;

    foreach (Trainer trainer in trainers)
    {
        trainer.IsThereELement(element);
    }
}
trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();
foreach (var trainer in trainers)
{
    Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
}
