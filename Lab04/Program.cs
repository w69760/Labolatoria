namespace Lab04z1
{
    class Program
    {
        //z1
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle());
            shapes.Add(new Triangle());
            shapes.Add(new Circle());

            foreach(var ksztalt in shapes)
            {
                ksztalt.Draw();
            }
        }
    }
}