using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_04.PizzaCalories;

public class Dough
{
    private const double BaseDoughCaloriesPerGram = 2;
    private const int MinWeight = 1;
    private const int MaxWeight = 200;
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get => flourType;
        set 
        {
            if (!(value == "white" || value == "wholegrain"))
            {
                throw new ArgumentException(string.Format(Exceptions.DoughException, "dough"));
            }
            flourType = value; 
        }
    }
    public string BakingTechnique
    {
        get => bakingTechnique;
        set
        {
            if (!(value == "crispy" || value == "chewy" || value == "homemade"))
            {
                throw new ArgumentException(string.Format(Exceptions.DoughException,"dough"));
            }
            bakingTechnique = value;
        }
    }
    public double Weight
    {
        get => weight;
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException
                    (string.Format(Exceptions.WeightException, nameof(Dough),MinWeight,MaxWeight));
            }
            weight = value;
        }
    }

    public double WeightDough()
    {
        double modifierType = 0;
        double modifierBakingTechnique = 0;
        switch(FlourType)
        {
            case "white":
                modifierType = 1.5;break;
            case "wholegrain":
                modifierType = 1; break;
        }
        switch (BakingTechnique)
        {
            case "crispy":
                modifierBakingTechnique = 0.9; break;
            case "chewy":
                modifierBakingTechnique = 1.1; break;
            case "homemade":
                modifierBakingTechnique = 1.0; break;
        }
        return BaseDoughCaloriesPerGram * Weight*modifierType*modifierBakingTechnique;
    }
}
