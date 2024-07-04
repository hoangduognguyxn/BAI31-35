using System;
using System.Text;

namespace Bai35
{
    public abstract class Shape
    {
        private int so_dinh;

        public virtual int SoDinh
        {
            get { return so_dinh; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Số đỉnh phải lớn hơn 0.");
                }
                so_dinh = value;
            }
        }
    }

    public class TamGiac : Shape
    {
        public TamGiac()
        {
            SoDinh = 3;
        }

        public override int SoDinh
        {
            get { return base.SoDinh; }
            set
            {
                if (value != 3)
                {
                    throw new ArgumentException("Tam giác phải có đúng 3 đỉnh.");
                }
                base.SoDinh = value;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                TamGiac tamGiac = new TamGiac();
                Console.WriteLine($"Số đỉnh của TamGiac: {tamGiac.SoDinh}");

                tamGiac.SoDinh = 4;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
