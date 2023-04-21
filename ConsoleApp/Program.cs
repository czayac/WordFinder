using System;
using System.Collections.Generic;


namespace WordFinderApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var dictionary = new string[] { "CHILL", "WIND", "SNOW", "COLD", "ABC","ACA" };

            IEnumerable<string> listaMatriz = new List<string>() { "ABCDCABCAE",
                                                                   "FGWIOWIOSR",
                                                                   "CHILLILLDF",
                                                                   "PQNSDNSDED",
                                                                   "JDDLISUCFS",
                                                                   "KFIEYDJFTS",
                                                                   "DACACADJHS",
                                                                   "ABCGSJDHCG",
                                                                   "PRWINDDJJC",
                                                                   "UVDXYWINDW" };
            try
            {

            var wordFinder = new WordFinder(listaMatriz);

            var listResult = wordFinder.Find(dictionary);

            Console.WriteLine(string.Join(",", listResult));     

            }
            catch (Exception ex)
            {

                throw ex;
            }


        
        }

    }

}