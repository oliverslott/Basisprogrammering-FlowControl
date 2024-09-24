/*
• Du skal programmere et klassisk Sten-Asks-Papir spil
• Løkker: Programmet skal bliver ved med at køre, så længe brugeren vil spille
igen. Brugeren kan skrive quit for at lukke spillet.
•
If-sætninger: Brug if-sætninger til at afgøre hvem der vinder hver runde baseret
på spillerens valg.
• Switch case: Brug en switch-case til at tage computerens valg, der er baseret på
et tilfældigt tal(1 for sten, 2 for saks, 3 for papir).
• Afleveres senest d. 07/10 på wiseflow
*/


Console.WriteLine("Velkommen til et spil sten, saks, papir. Skriv \"sten\",\"saks\" eller \"papir\" Du kan også skrive \"quit\" for at stoppe");

// while(true)
// {
//     Console.WriteLine();
//     Console.Write("Valg: ");
//     string spillerValg = Console.ReadLine().ToLower();
//     if(spillerValg == "quit")
//     {
//         break;
//     }
//     if(spillerValg != "sten" && spillerValg != "saks" && spillerValg != "papir")
//     {
//         Console.WriteLine("Det er ikke en mulighed! Prøv igen!");
//         continue;
//     }

//     var rand = new Random();
//     int ai = rand.Next(1, 4);
//     string aiValg = "";
//     switch (ai)
//     {
//         case 1:
//             aiValg = "sten";
//             break;
//         case 2:
//             aiValg = "saks";
//             break;
//         case 3:
//             aiValg = "papir";
//             break;
//     }
//     Console.WriteLine($"Computeren har valgt: {aiValg}");
//     bool spillerVandt = false;
//     if(spillerValg == aiValg)
//     {
//         Console.WriteLine("Det blev uafgjort!");
//         continue;
//     } 
//     //Dette er ikke pretty, men det virker :,)
//     else if(spillerValg == "sten")
//     {
//         if (aiValg == "saks")
//         {
//             spillerVandt = true;
//         }
//         else if(aiValg == "papir")
//         {
//             spillerVandt = false;
//         }
//     } 
//     else if(spillerValg == "saks")
//     {
//         if(aiValg == "sten")
//         {
//             spillerVandt = false;
//         } 
//         else if(aiValg == "papir")
//         {
//             spillerVandt = true;
//         }
//     }
//     else if(spillerValg == "papir")
//     {
//         if(aiValg == "saks")
//         {
//             spillerVandt = false;
//         }
//         else if(aiValg == "sten")
//         {
//             spillerVandt = true;
//         }
//     }
//     if(spillerVandt)
//     {
//         Console.WriteLine("Du vandt!");
//     } 
//     else {
//         Console.WriteLine("Du tabte!");
//     }
// }

//Jeg fik en bedre ide
while(true)
{
    Console.WriteLine();
    Console.Write("Valg: ");
    string spillerValg = Console.ReadLine().ToLower();
    if(spillerValg == "quit")
    {
        break;
    }
    if(spillerValg != "sten" && spillerValg != "saks" && spillerValg != "papir")
    {
        Console.WriteLine("Det er ikke en mulighed! Prøv igen!");
        continue;
    }
    
    IValg playerChosen;
    switch(spillerValg)
    {
        case "sten":
            playerChosen = new Sten();
            break;
        case "papir":
            playerChosen = new Papir();
            break;
        case "saks":
            playerChosen = new Saks();
            break;
        default:
            Console.WriteLine("Det er ikke en mulighed!");
            continue;
    }
    var rand = new Random();
    int ai = rand.Next(1, 4);
    string aiValg;
    IValg aiChosen;
    switch (ai)
    {
        case 1:
            aiValg = "sten";
            aiChosen = new Sten();
            break;
        case 2:
            aiValg = "saks";
            aiChosen = new Saks();
            break;
        case 3:
            aiValg = "papir";
            aiChosen = new Papir();
            break;
        default:
            return;
    }
    Console.WriteLine($"Computeren har valgt: {aiValg}");
    if(playerChosen.GetType() == aiChosen.GetType())
    {
        Console.WriteLine("Det blev uafgjort!");
    }
    if(playerChosen.VinderOver(aiChosen))
    {
        Console.WriteLine("Du vandt!");
    }
    else
    {
        Console.WriteLine("Du tabte");
    }
}

public interface IValg
{
    public bool VinderOver(IValg modstander);
}

public class Saks : IValg
{
    public bool VinderOver(IValg modstander)
    {
        return modstander.GetType() == typeof(Papir);
    }
}

public class Sten : IValg
{
    public bool VinderOver(IValg modstander)
    {
        return modstander.GetType() == typeof(Saks);
    }
}

public class Papir : IValg
{
    public bool VinderOver(IValg modstander)
    {
        return modstander.GetType() == typeof(Sten);
    }
}
