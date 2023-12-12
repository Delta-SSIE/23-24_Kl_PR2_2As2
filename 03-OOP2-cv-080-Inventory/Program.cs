namespace _03_OOP2_cv_080_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character mehmet = new Character("Mehmet", 250, 100);
            Character ahmed  = new Character("Ahmed" , 250, 110);

            Weapon sword = new Weapon("Sword", 30, 7);
            Weapon axe = new Weapon("Axe", 40, 9);

            Armor leather = new Armor("Leather armor", 25, 2);

            Shield shield = new Shield("Buckler", 10, 1);

            mehmet.AddItem(sword);
            mehmet.AddItem(leather);
            mehmet.Equip(sword);
            mehmet.Equip(leather);

            ahmed.AddItem(axe);
            ahmed.AddItem(shield);
            ahmed.Equip(axe);
            ahmed.Equip(shield);

            FileLogger logger = new FileLogger("zaznam.txt");
            //Combat combat = new Combat(mehmet, ahmed, new ConsoleLogger() );
            Combat combat = new Combat(mehmet, ahmed, logger );

            combat.Fight();



            //Item wine = new Item("Wine", 5);
            //StackableItem bread = new StackableItem("Bread", 10, 2);

            //mehmet.AddItem(bread);
            //mehmet.AddItem(wine);

            //Console.WriteLine(mehmet.ListInventory());

            //mehmet.DropItem(wine);
            //Console.WriteLine(mehmet.ListInventory());

            ////mehmet.DropItem(wine);
            ////Console.WriteLine(mehmet.ListInventory());

            //mehmet.DropItem(bread, 1 );
            //Console.WriteLine(mehmet.ListInventory());

            ////mehmet.DropItem(bread, 2);
            ////Console.WriteLine(mehmet.ListInventory());

            //mehmet.DropItem(bread, 1);
            //Console.WriteLine(mehmet.ListInventory());


            //mehmet.AddItem(new Gold(10));
            //mehmet.AddItem(new Gold(5));
            //mehmet.AddItem(new Copper(154));
            //mehmet.AddItem(new Silver(21));
            //Console.WriteLine(mehmet.ListInventory());
            //Console.WriteLine(mehmet.Balance);




        }
    }
}
