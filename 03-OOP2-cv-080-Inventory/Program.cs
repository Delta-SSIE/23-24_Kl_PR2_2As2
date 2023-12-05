namespace _03_OOP2_cv_080_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character mehmet = new Character("Mehmet", 250);

            Item wine = new Item("Wine", 5);
            StackableItem bread = new StackableItem("Bread", 10, 2);

            mehmet.AddItem(bread);
            mehmet.AddItem(wine);

            Console.WriteLine(mehmet.ListInventory());

            mehmet.DropItem(wine);
            Console.WriteLine(mehmet.ListInventory());

            //mehmet.DropItem(wine);
            //Console.WriteLine(mehmet.ListInventory());

            mehmet.DropItem(bread, 1 );
            Console.WriteLine(mehmet.ListInventory());

            //mehmet.DropItem(bread, 2);
            //Console.WriteLine(mehmet.ListInventory());

            mehmet.DropItem(bread, 1);
            Console.WriteLine(mehmet.ListInventory());


            mehmet.AddItem(new Gold(10));
            mehmet.AddItem(new Gold(5));
            mehmet.AddItem(new Copper(154));
            mehmet.AddItem(new Silver(21));
            Console.WriteLine(mehmet.ListInventory());
            Console.WriteLine(mehmet.Balance);

            
            

        }
    }
}
