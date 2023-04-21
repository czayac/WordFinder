using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordFinderApp
{
    public class WordFinder: IWordFinder
    {
        #region Const

        private IEnumerable<string> listaMatriz;

        #endregion

        #region Constructor 

        public WordFinder(IEnumerable<string> matriz)
        {

            listaMatriz = matriz;

        }

        #endregion

        #region Public Method

        public IEnumerable<string> Find(IEnumerable<string> dictionary)
        {

            var listaMatrizPivot = PivotList(listaMatriz);
            var listaMatrizString = string.Join("_", listaMatriz);
            var listaMatrizPivotString = string.Join("_", listaMatrizPivot);
            var listResult = new Dictionary<string, int>();


            foreach (var word in dictionary)
            {
                int findInMatriz = new Regex(Regex.Escape(word)).Matches(listaMatrizString).Count;
                int findInMatrizPivot = new Regex(Regex.Escape(word)).Matches(listaMatrizPivotString).Count;

                if ((findInMatriz + findInMatrizPivot) > 0)
                listResult.Add(word, findInMatriz + findInMatrizPivot);
            }
           // Codigo para ver cantidad de palabras encontradas
           // var orderListDetail = listResult.OrderByDescending(x => x.Value);

            var orderList = listResult.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            return orderList;


        }
        #endregion

        #region Private Method

        private IEnumerable<string> PivotList(IEnumerable<string> matriz)
        {
            List<string> pivotList = new List<string>();

            var characterMatriz = matriz
                .Select(row => row.ToCharArray())
                .ToArray();

            StringBuilder toVerticalStringBuilder;

            for (var i = 0; i < characterMatriz.Length; i++)
            {
                toVerticalStringBuilder = new StringBuilder();
                for (var j = 0; j < characterMatriz[i].Length; j++)
                {
                    toVerticalStringBuilder.Append(characterMatriz[j][i]);
                }
                pivotList.Add(toVerticalStringBuilder.ToString());
            }

            return pivotList;
        }

        #endregion
    }
}
