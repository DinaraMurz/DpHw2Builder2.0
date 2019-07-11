using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw2Builder2._0
{

    // Абстракция устанавливает интерфейс для «управляющей» части двух иерархий
    // классов. Она содержит ссылку на объект из иерархии Реализации и
    // делегирует ему всю настоящую работу.
    /// <summary>
    /// jgj
    /// 
    /// </summary>
    /// 


    public class Dell
    {
        public string Mainboard { get; set; }
        public string Processor { get; set; }
        public string VideoCard { get; set; }
        public string SoundCard { get; set; }
        public string Tuner { get; set; }

        public Dell(string mainboard, string processor, string videoCard, string soundCard, string tuner)
        {
            Mainboard = mainboard;
            Processor = processor;
            VideoCard = videoCard;
            SoundCard = soundCard;
            Tuner = tuner;
        }
    }

    public class Sony
    {
        public string Mainboard { get; set; }
        public string Processor { get; set; }
        public string VideoCard { get; set; }
        public string SoundCard { get; set; }
        public string Tuner { get; set; }

        public Sony(string mainboard, string processor, string videoCard, string soundCard, string tuner)
        {
            Mainboard = mainboard;
            Processor = processor;
            VideoCard = videoCard;
            SoundCard = soundCard;
            Tuner = tuner;
        }
    }


    public class DellBuilder : IBuilder
    {
        public void Mainboard()
        {
            Console.WriteLine("Dell Mainboard");
        }

        public void Processor()
        {
            Console.WriteLine("Dell Processor");
        }

        public void VideoCard()
        {
            Console.WriteLine("Dell VideoCard");
        }

        public void SoundCard()
        {
            Console.WriteLine("Dell SoundCard");
        }

        public void Tuner()
        {
            Console.WriteLine("Dell Tuner");
        }
    }

    public class SonyBuilder : IBuilder
    {
        public void Mainboard()
        {
            Console.WriteLine("Sony Mainboard");
        }

        public void Processor()
        {
            Console.WriteLine("Sony Processor");
        }

        public void VideoCard()
        {
            Console.WriteLine("Sony VideoCard");
        }

        public void SoundCard()
        {
            Console.WriteLine("Sony SoundCard");
        }

        public void Tuner()
        {
            Console.WriteLine("Sony Tuner");
        }
    }

    public interface IBuilder
    {
        void Mainboard();

        void Processor();

        void VideoCard();

        void SoundCard();

        void Tuner();
    }


    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        // Директор может строить несколько вариаций продукта, используя
        // одинаковые шаги построения.
        public void Basic()
        {
            this._builder.Mainboard();
            this._builder.Processor();
        }
        public void Standard()
        {
            this._builder.Mainboard();
            this._builder.Processor();
            this._builder.VideoCard();
        }
        public void StandardPlus()
        {
            this._builder.Mainboard();
            this._builder.Processor();
            this._builder.VideoCard();
            this._builder.SoundCard();
        }
        public void Lux()
        {
            this._builder.Mainboard();
            this._builder.Processor();
            this._builder.VideoCard();
            this._builder.SoundCard();
            this._builder.Tuner();
        }

        //public void buildFullFeaturedProduct()
        //{
        //    this._builder.BuildPartA();
        //    this._builder.BuildPartB();
        //    this._builder.BuildPartC();
        //}
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DellBuilder dellBuilder = new DellBuilder();
            Director director = new Director(dellBuilder);
            Console.WriteLine("  Dell Basic have: ");
            director.Basic();
            Console.WriteLine("\n  Dell Lux have: ");
            director.Lux();

            SonyBuilder sonyBuilder = new SonyBuilder();
            director = new Director(sonyBuilder);
            Console.WriteLine("\n  Sony Basic have: ");
            director.Basic();
            Console.WriteLine("\n  Sony Lux have: ");
            director.Lux();
        }
    }
}
